using System;
using Microsoft.AspNetCore.Mvc;
using static MyWeb.NSwag.SwaggerFilChunkUploadOperationProcessor;

namespace MyWeb.Controllers {
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UploadController : ControllerBase {

        [SwaggerFileChunkUpload]
        public IActionResult Upload() {
            Console.WriteLine("> Request.Form");
            foreach (var item in this.Request.Form) {
                Console.WriteLine($"  Key: {item.Key}, Value: {item.Value}");
            }

            Console.WriteLine("> Request.Form.Files");
            foreach (var item in this.Request.Form.Files) {
                Console.WriteLine("  FileName: {0}", item.FileName);
                Console.WriteLine("  Name: {0}", item.Name);
                Console.WriteLine("  ContentType: {0}", item.ContentType);
                Console.WriteLine("  Length: {0}", item.Length);
            }

            return Ok();
        }
    }
}