using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<NumbersResult> GetNumbers()
        {
            var request = new HttpRequest(ApiEndpoints.Numbers);
            var response = await httpClient.ExecuteAsync<NumbersResult>(request);
            return response;
        }

        public async Task<NumberInfoResult> GetNumber(string numeralSystem)
        {
            var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem));
            var response = await httpClient.ExecuteAsync<NumberInfoResult>(request);
            return response;
        }

    }
}
