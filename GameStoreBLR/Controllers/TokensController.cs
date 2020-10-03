using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using DAL;
using GameStoreBLR.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace GameStoreBLR.Controllers {
    public class TokensController : ControllerBase {
        private readonly ILogger<TokensController> _logger;
        private IUnitOfWork _unitOfWork;

        public TokensController(ILogger<TokensController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/tokens")]
        public string Generate_Tokens(string email, string password) {
            _logger.LogInformation($"Request - email:{email} password:{password}");

            long? userId = null;

            var identity = GetIdentity(email, password, out userId);

            if (identity == null) {
                var errorText = "Invalid email or password.";
                HttpContext.Response.StatusCode = 400;
                return JsonSerializer.Serialize(errorText);
            }

            var now = DateTime.UtcNow;

            var encodedAccessToken = Generate_Access_Token(identity);

            var encodedRefreshToken = Generate_Refresh_Token((long)userId, email);

            HttpContext.Response.Cookies.Append(
                "Refresh_token",
                encodedRefreshToken,
                new CookieOptions {
                    HttpOnly = true
                }
                );

            var response = new {
                access_token = encodedAccessToken,
                email = identity.Name
            };

            return JsonSerializer.Serialize(response);
        }

        private string Generate_Access_Token(ClaimsIdentity identity) {
            var now = DateTime.UtcNow;

            // создаем JWT-Access-токен
            var jwt_access = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.ACCESS_TOKEN_LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt_access);
        }

        private string Generate_Refresh_Token(long userId, string email) {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(randomNumber);
                _unitOfWork.RefreshTokensRepository.Add(new RefreshTokens() { UserId = (long)userId, Token = Convert.ToBase64String(randomNumber), ExpiryDate = DateTime.UtcNow.AddDays(31) });
                return Convert.ToBase64String(randomNumber);
            }
        }

        [HttpGet("/refreshtokens")]
        public void RefreshTokens(ClaimsIdentity claimsIdentity) {

        }

        private ClaimsIdentity GetIdentity(string email, string password, out long? userId) {
            Users user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(x => x.Email == email && x.Password == password);
            userId = user?.Id;
            if (user != null) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                HttpContext.Session.SetString("UserLogin", user.Login);
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}