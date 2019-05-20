using Kata001.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata001.Interface
{
    public interface IClientService
    {
        Task<List<ApiResponse>> GetMultipleResponsesAsync(List<string> sources);
    }
}
