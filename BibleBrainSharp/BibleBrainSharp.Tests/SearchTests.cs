using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class SearchTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task Search()
    {
        var searches = await client.ApiClient.Search("love", "ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(searches);
    }

    [Fact]
    public async Task SearchPaginated()
    {
        var searches = await client.ApiClient.SearchPaginated(1, "love", "ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(searches);
    }

    [Fact]
    public async Task SearchPaginatedJson()
    {
        var searches = await client.ApiClient.SearchPaginatedJson(1, "love", "ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(searches);
    }
}
