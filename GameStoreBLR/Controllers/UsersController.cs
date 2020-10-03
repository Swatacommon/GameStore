using System;
using System.Collections.Generic;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace GameStoreBLR.Controllers {
    public class UsersController : ControllerBase {

        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("users")]
        [Authorize]
        public IEnumerable<Users> Get() {
            _logger.LogInformation("Get users");
            return _unitOfWork.UserRepository.GetAll();
        }

        [HttpGet("users/{id}")]
        [Authorize] 
        public Users Get(long id) {
            _logger.LogInformation($"Get user by id = {id}");
            return _unitOfWork.UserRepository.GetById(id);
        }

        [HttpPost("/signup")]
        public Users Add(string login, string email, string password) {
            _logger.LogInformation($"Register user");
            var newUser = _unitOfWork.UserRepository.Add(new Users() { Login = login, Email = email, Password = password });
            _unitOfWork.Commit();
            return newUser;
        }
    }
}