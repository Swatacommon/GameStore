using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using DAL;
using GameStoreBLR.Services;
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

        [HttpPost("/accesstoken")]
        public string Token(string email, string password) {
            _logger.LogInformation($"Request - email:{email} password:{password}");
            var identity = GetIdentity(email, password);
            if (identity == null) {
                var errorText = "Invalid email or password.";
                return JsonSerializer.Serialize(errorText);
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new {
                access_token = encodedJwt,
                email = identity.Name
            };

            return JsonSerializer.Serialize(response);
        }

        private ClaimsIdentity GetIdentity(string email, string password) {
            Users user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}