using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using GameStoreBLR.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameStoreBLR.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase {
        private readonly ILogger<ImagesController> _logger;
        private readonly IBlobService _blobService;

        public ImagesController(ILogger<ImagesController> logger, IBlobService blobService) {
            _logger = logger;
            _blobService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> doGet() {
            return Ok(await _blobService.ListBlobAsync());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> doGet(string name) {
            var blob = await _blobService.GetBlobAsync(name);
            return File(blob.Content, blob.ContentType);
        }
    }
}