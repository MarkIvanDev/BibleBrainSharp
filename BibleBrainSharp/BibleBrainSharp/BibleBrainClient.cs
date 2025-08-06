using System;
using System.Net.Http;

namespace BibleBrainSharp;

public partial class BibleBrainClient : IDisposable
{
    private readonly HttpClient httpClient;

    public BibleBrainClient(string apiKey)
        : this(
              new BibleBrainClientOptions()
              {
                  ApiKey = apiKey
              },
              new HttpClient())
    {
    }

    public BibleBrainClient(string apiKey, HttpClient httpClient)
        : this(
              new BibleBrainClientOptions()
              {
                  ApiKey = apiKey
              },
              httpClient)
    {
    }

    public BibleBrainClient(BibleBrainClientOptions options, HttpClient httpClient)
    {
        this.httpClient = httpClient;
        this.httpClient.BaseAddress = new Uri(ApiEndpoints.Base);
        this.httpClient.DefaultRequestHeaders.Add("v", "4");
        this.httpClient.DefaultRequestHeaders.Add("key", options.ApiKey);
    }

    public void Dispose()
    {
        httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}

public class BibleBrainClientOptions
{
    public string ApiKey { get; init; } = string.Empty;

    public bool RethrowExceptions { get; init; }
}
