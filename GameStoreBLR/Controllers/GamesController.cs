using System;
using System.Collections.Generic;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace GameStoreBLR.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase {

        private readonly ILogger<GamesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(ILogger<GamesController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Games> Get() {
            _logger.LogInformation(Environment.GetEnvironmentVariable("Get games"));
            return _unitOfWork.GameRepository.GetAllWithIncludes();
        }

        [HttpGet("{id}")]
        public Games Get(long id) {
            _logger.LogInformation($"Get game by id = {id}");
            return _unitOfWork.GameRepository.GetById(id);
        }

        [HttpDelete("{id}")]
        public Games DeleteById(long id) {
            _logger.LogInformation($"Delete game by id = {id}");
            return _unitOfWork.GameRepository.RemoveById(id);
        }
    }
}
