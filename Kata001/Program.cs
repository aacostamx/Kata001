using Kata001.Interface;
using Kata001.Models;
using Kata001.Services;
using RestSharp;
using SimpleInjector;
using System.Threading.Tasks;

namespace Kata001
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();

            container.Register<IClientService, ClientService>();
            container.Register<IClockService, ClockService>();
            container.Register<IFileService, FileService>();

            container.Verify();
        }

        static async Task Main(string[] args)
        {
            var clientService = container.GetInstance<IClientService>();
            var clockService = container.GetInstance<IClockService>();
            var fileService = container.GetInstance<IFileService>();


            var client = new RestClient("http://www.mocky.io/v2/5b5f00232e00009a0a69477e");

            var response = client.Execute<ObjectResponse>(new RestRequest());

            ObjectResponse test =  response.Data;

            //var sources = new List<string>()
            //{
            //    "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
            //    "http://www.mocky.io/v2/5b5f00962e00009a0a694782"
            //};
            //var headers = "source, temp, processstart";
            //var filename = $"data-{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.csv";
            //File.WriteAllText(filename, $"{headers}{Environment.NewLine}");
            //foreach(var source in sources)
            //{
            //    using (var client = new HttpClient())
            //    {
            //        var response = await client.GetAsync(source);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var result = await response.Content.ReadAsStringAsync();
            //            var tempString = result.Split(":")[1].Replace("}", "").Replace(Environment.NewLine, "");
            //            int temp = 0;
            //            var success = int.TryParse(tempString, out temp);
            //            if (success)
            //            {
            //                File.AppendAllText(filename, $"{source},{temp},{DateTime.Now.ToUniversalTime()}{Environment.NewLine}");
            //            }
            //        }
            //    }
            //}
        }
    }
}
