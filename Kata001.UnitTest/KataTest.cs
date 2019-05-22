using Kata001.Interface;
using Kata001.Models;
using Kata001.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Kata001.UnitTest
{
    public class KataTest
    {

        public List<string> Sources { get; set; }

        public List<ApiResponse> ApiResponse { get; set; }

        public KataTest()
        {
            Sources = new List<string>()
            {
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782",
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782",
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782",
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782",
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782",
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782"
            };

            ApiResponse = new List<ApiResponse>()
            {
                new ApiResponse { Temp = 100, Source = "https://www.4thsource.com/" },
                new ApiResponse { Temp = 101, Source = "https://www.anglobal.com/en/" }
            };
        }

        [Fact]
        public void Get_Multiple_Responses_Async()
        {
            // Arrange
            IClientService client = new ClientService();

            // Act
            Task<List<ApiResponse>> response = client.GetMultipleResponsesAsync(Sources);

            // Assert
            Assert.NotNull(response.Result);
            Assert.Equal(Sources.Count, response.Result.Count);
            Assert.IsAssignableFrom<List<ApiResponse>>(response.Result);
        }

        [Fact]
        public void Get_Date_Time_Now_UTC()
        {
            IClockService clock = new ClockService();

            DateTimeOffset nowUTC = clock.NowUTC;

            Assert.IsNotType<DateTime>(nowUTC);
            Assert.NotEqual(nowUTC, clock.NowUTC);
            Assert.IsAssignableFrom<DateTimeOffset>(nowUTC);
        }

        [Fact]
        public void Get_Headers()
        {
            IFileService fileService = new FileService();

            string headers = fileService.Headers;

            Assert.NotNull(headers);
            Assert.NotEmpty(headers);
            Assert.IsAssignableFrom<string>(headers);
            Assert.Equal(headers, fileService.Headers);
        }

        [Fact]
        public void Get_File_Name()
        {
            IFileService fileService = new FileService();

            string fileName = fileService.FileName;

            Assert.NotNull(fileName);
            Assert.NotEmpty(fileName);
            Assert.IsAssignableFrom<string>(fileName);
            Assert.Contains(fileName, fileService.FileName);
        }

    }
}
