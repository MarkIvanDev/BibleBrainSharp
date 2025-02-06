global using Xunit;
using Microsoft.Extensions.Configuration;

namespace BibleBrainSharp.Tests;

public static class Client
{
    public static readonly BibleBrainClient ApiClient;

    static Client()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Secrets>()
            .Build();
        ApiClient = new BibleBrainClient(configuration["ApiKey"]!);
    }
}

public class Secrets { }
