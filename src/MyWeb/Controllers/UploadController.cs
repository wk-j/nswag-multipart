using Microsoft.AspNetCore.Mvc;
using static MyWeb.NSwag.SwaggerFilChunkUploadOperationProcessor;

namespace MyWeb.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UploadController : ControllerBase {

        [SwaggerFileChunkUpload]
        public IActionResult Upload() {
            return Ok();
        }
    }
}