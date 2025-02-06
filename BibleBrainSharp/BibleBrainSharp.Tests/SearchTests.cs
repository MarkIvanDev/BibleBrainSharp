namespace BibleBrainSharp.Tests;

public class SearchTests
{
    [Fact]
    public async Task Search()
    {
        var searches = await Client.ApiClient.Search("love", "ENGKJV");
        Assert.NotEmpty(searches);
    }

    [Fact]
    public async Task SearchPaginated()
    {
        var searches = await Client.ApiClient.SearchPaginated(1, "love", "ENGKJV");
        Assert.NotNull(searches);
    }
}
