using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using KService.Client;
using Newtonsoft.Json;

namespace MyClient {
    class Program {
        static async Task Main(string[] args) {
            var baseUrl = "http://localhost:5000";
            var client = new HttpClient();
            var upload = new UploadClient(baseUrl, client);

            var bytes = File.ReadAllBytes("README.md");
            var stream = new MemoryStream(bytes);

            var file = new FileParameter(stream, "README.md", "plain/text");

            var meta = new Metadata {
                F1 = "F1",
                F2 = "F2",
                F3 = "F3"
            };

            var json = JsonConvert.SerializeObject(meta);
            var rs = await upload.UploadWithMetadataAsync(file, json);
        }
    }
}
