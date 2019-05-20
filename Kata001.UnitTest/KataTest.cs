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

        public KataTest()
        {
            Sources = new List<string>()
            {
                "http://www.mocky.io/v2/5b5f00232e00009a0a69477e",
                "http://www.mocky.io/v2/5b5f00962e00009a0a694782"
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
            Assert.Equal(2, response.Result.Count);
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

    }
}
