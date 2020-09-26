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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly ILogger<OrderController> _logger;
        private IUnitOfWork _unitOfWork;

        public OrderController(ILogger<OrderController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpGet("tocard/{id}")]
        public ActionResult AddToCart(string id) {
            if (id != null) {
                if (long.TryParse(id, out long _id)) {
                    Games game = _unitOfWork.GameRepository.GetById(_id);
                    HttpContext.Session.SetString($"{game.Id}", game.Name);
                    return Ok();
                }
            }
            return Redirect(HttpContext.Request.Host + "/authorization");
        }
    }
}