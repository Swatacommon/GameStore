using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStoreBLR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IUnitOfWork _unitOfWork;

        public OrderController(ILogger<OrderController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpPost("/AddToCart")]
        public ActionResult AddToCart(string id) {
            HttpContext.Session.SetString("Id", id);
            return Ok();
        }
    }
}