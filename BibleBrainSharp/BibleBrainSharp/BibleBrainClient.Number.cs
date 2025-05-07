using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<NumbersResult?> GetNumbers()
        {
            var request = new HttpRequest(ApiEndpoints.Numbers);
            var response = await httpClient.ExecuteAsync<NumbersResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<string?> GetNumbersJson()
        {
            var request = new HttpRequest(ApiEndpoints.Numbers);
            var response = await httpClient.ExecuteJsonAsync(request).ConfigureAwait(false);
            return response;
        }

        public async Task<NumberInfoResult?> GetNumber(string numeralSystem)
        {
            var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem));
            var response = await httpClient.ExecuteAsync<NumberInfoResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<string?> GetNumberJson(string numeralSystem)
        {
            var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem));
            var response = await httpClient.ExecuteJsonAsync(request).ConfigureAwait(false);
            return response;
        }

    }
}
