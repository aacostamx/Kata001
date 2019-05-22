using Kata001.Interface;
using Kata001.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kata001.Services
{
    public class ClientService : IClientService
    {
        private static readonly HttpClientHandler ClientHandler = new HttpClientHandler();

        public async Task<List<ApiResponse>> GetMultipleResponsesAsync(List<string> sources)
        {
            var responses = new List<ApiResponse>();

            try
            {
                using (var client = new HttpClient(ClientHandler, false))
                {
                    foreach (var url in sources)
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            string tempString = result.Split(":")[1].Replace("}", "").Replace(Environment.NewLine, "");
                            if (int.TryParse(tempString, out int temp))
                            {
                                responses.Add(new ApiResponse { Temp = temp, Source = url });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return responses;
        }
    }
}
