using System.Threading.Tasks;
using GameStoreBLR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
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

        [HttpPost]
        public async Task<IActionResult> doPost([FromBody] UploadFileRequest request) {
            await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName);
            return Ok();
        }
    }
}