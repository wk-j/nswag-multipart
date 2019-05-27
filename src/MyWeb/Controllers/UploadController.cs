using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static MyWeb.NSwag.SwaggerFilChunkUploadOperationProcessor;

namespace MyWeb.Controllers {
    public class Metadata {
        public string F1 { set; get; }
        public string F2 { set; get; }
        public string F3 { set; get; }
    }

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UploadController : ControllerBase {

        [HttpPost]
        public IActionResult Metadata(Metadata data) {
            return Ok();
        }

        [SwaggerFileChunkUpload]
        public async System.Threading.Tasks.Task<IActionResult> UploadWithMetadataAsync() {

            Request.Form.TryGetValue("json", out var json);
            var meta = JsonConvert.DeserializeObject<Metadata>(json);

            Console.WriteLine(meta.F1);

            var file = Request.Form.Files.GetFile("file");
            using (var stream = new FileStream("../../.client/README.md", FileMode.OpenOrCreate)) {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }

        [SwaggerFileChunkUpload]
        [HttpPost]
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