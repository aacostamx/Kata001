
using Kata001.Interface;
using Kata001.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Kata001.Services
{
    public class FileService : IFileService
    {
        readonly Container container;

        public FileService()
        {
            container = new Container();
            container.Register<IClockService, ClockService>();
            container.Verify();
        }

        public void CreateCVSFile(List<ApiResponse> table)
        {
            try
            {
                IClockService clockService = container.GetInstance<IClockService>();

                var headers = "source, temp, processstart";
                var filename = $"data-{clockService.NowUTC.ToString("yyyy-dd-M--HH-mm-ss")}.csv";
                File.WriteAllText(filename, $"{headers}{Environment.NewLine}");

                foreach (var row in table)
                {
                    File.AppendAllText(filename, $"{row.Source},{row.Temp},{clockService.NowUTC}{Environment.NewLine}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
