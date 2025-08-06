using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class AlphabetTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task GetAlphabets()
    {
        var alphabets = await client.ApiClient.GetAlphabets(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(alphabets);
    }

    [Fact]
    public async Task GetAlphabetsJson()
    {
        var alphabets = await client.ApiClient.GetAlphabetsJson(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(alphabets);
    }

    [Fact]
    public async Task GetAlphabet()
    {
        var alphabet = await client.ApiClient.GetAlphabet("Latn", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(alphabet);
    }

    [Fact]
    public async Task GetAlphabetJson()
    {
        var alphabet = await client.ApiClient.GetAlphabetJson("Latn", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(alphabet);
    }
}