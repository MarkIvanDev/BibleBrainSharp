using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class AlphabetTests
{
    private readonly Client client;

    public AlphabetTests(Client client)
    {
        this.client = client;
    }


    [Fact]
    public async Task GetAlphabets()
    {
        var alphabets = await client.ApiClient.GetAlphabets(TestContext.Current.CancellationToken);
        Assert.NotNull(alphabets);
    }

    [Fact]
    public async Task GetAlphabet()
    {
        var alphabet = await client.ApiClient.GetAlphabet("Latn", TestContext.Current.CancellationToken);
        Assert.NotNull(alphabet);
    }
}