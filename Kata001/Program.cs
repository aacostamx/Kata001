using Kata001.Interface;
using Kata001.Models;
using Kata001.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kata001
{
    internal class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Register<IClientService, ClientService>();
            container.Register<IFileService, FileService>();
            container.Verify();
        }

        static async Task Main(string[] args)
        {
            IClientService clientService = container.GetInstance<IClientService>();
            IFileService fileService = container.GetInstance<IFileService>();

            var sources = new List<string>()
            {
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782"
            };

            fileService.CreateCVSFile(await clientService.GetMultipleResponsesAsync(sources));
        }
    }
}
