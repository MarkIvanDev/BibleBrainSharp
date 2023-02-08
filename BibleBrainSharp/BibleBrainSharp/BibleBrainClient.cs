using System;
using System.Net.Http;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public BibleBrainClient(string apiKey) : this(apiKey, new HttpClient())
        {
        }

        public BibleBrainClient(string apiKey, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(ApiEndpoints.Base);
            this.httpClient.DefaultRequestHeaders.Add("v", "4");
            this.httpClient.DefaultRequestHeaders.Add("key", apiKey);
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
