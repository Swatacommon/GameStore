using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Authorize]
        [HttpGet]
        public IEnumerable<Users> Get() {
            _logger.LogInformation(Environment.GetEnvironmentVariable("Get users"));
            return _unitOfWork.UserRepository.GetAll();
        }

        [Authorize]
        [HttpGet("{id}")]
        public Users Get(long id) {
            _logger.LogInformation($"Get user by id = {id}");
            return _unitOfWork.UserRepository.GetById(id);
        }

        [AllowAnonymous]
        [HttpPost("/signup")]
        public Users Add(string login, string email, string password) {
            _logger.LogInformation($"Register user");
            return _unitOfWork.UserRepository.Add(new Users() { Login = login, Email = email, Password = password});
        }
    }
}