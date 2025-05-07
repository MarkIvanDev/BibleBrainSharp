using BibleBrainSharp.Tests.Fixtures;
using Microsoft.Extensions.Configuration;

[assembly: AssemblyFixture(typeof(Client))]

namespace BibleBrainSharp.Tests.Fixtures;

public sealed class Client : IDisposable
{
    public readonly BibleBrainClient ApiClient;

    public Client()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Secrets>()
            .Build();
        ApiClient = new BibleBrainClient(configuration["ApiKey"]!);
    }

    public void Dispose()
    {
        ApiClient.Dispose();
    }
}

public class Secrets { }
