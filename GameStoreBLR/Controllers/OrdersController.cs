using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace GameStoreBLR.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase {
        private readonly ILogger<OrdersController> _logger;
        private IUnitOfWork _unitOfWork;

        public OrdersController(ILogger<OrdersController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Orders> GetOrders() {
            _logger.LogInformation("GetUserOrders");
            string idStr = HttpContext.Session.GetString("UserId");
            long.TryParse(idStr, out long id);
            return _unitOfWork.OrderRepository.GetAll().Where(order => order.UserId == id);
        }
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