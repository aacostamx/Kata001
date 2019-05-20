
using Kata001.Interface;
using Kata001.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kata001.Services
{
    public class FileService : IFileService
    {
        private Container Container { get; set; }

        private IClockService ClockService { get; set; }

        public FileService()
        {
            Container = new Container();
            Container.Register<IClockService, ClockService>();
            Container.Verify();

            ClockService = Container.GetInstance<IClockService>();
        }

        public string Headers => "source, temp, processstart";

        public string FileName => $"data-{ClockService.NowUTC.ToString("yyyy-dd-M--HH-mm-ss")}.csv";

        public void CreateCVSFile(List<ApiResponse> table)
        {
            try
            {
                var headers = "source, temp, processstart";
                var filename = $"data-{ClockService.NowUTC.ToString("yyyy-dd-M--HH-mm-ss")}.csv";
                File.WriteAllText(filename, $"{headers}{Environment.NewLine}");

                foreach (var row in table)
                {
                    File.AppendAllText(filename, $"{row.Source},{row.Temp},{ClockService.NowUTC}{Environment.NewLine}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
