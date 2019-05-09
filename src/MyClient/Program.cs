using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using KService.Client;

namespace MyClient {
    class Program {
        static async Task Main(string[] args) {
            var baseUrl = "http://localhost:5000";
            var client = new HttpClient();
            var upload = new UploadClient(baseUrl, client);

            var bytes = File.ReadAllBytes("README.md");
            var stream = new MemoryStream(bytes);

            var file = new FileParameter(stream, "README.md", "plain/text");

            var rs = await upload.UploadAsync(file, "f-README.md");
        }
    }
}
