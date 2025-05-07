using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class SearchTests
{
    private readonly Client client;

    public SearchTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task Search()
    {
        var searches = await client.ApiClient.Search("love", "ENGKJV");
        Assert.NotEmpty(searches);
    }

    [Fact]
    public async Task SearchPaginated()
    {
        var searches = await client.ApiClient.SearchPaginated(1, "love", "ENGKJV");
        Assert.NotNull(searches);
    }
}
