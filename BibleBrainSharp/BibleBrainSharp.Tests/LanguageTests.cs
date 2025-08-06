using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class LanguageTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task GetLanguages()
    {
        var languages = await client.ApiClient.GetLanguages(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(languages);
    }

    [Fact]
    public async Task GetLanguagesPaginated()
    {
        var languages = await client.ApiClient.GetLanguagesPaginated(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(languages);
    }

    [Fact]
    public async Task GetLanguagesPaginatedJson()
    {
        var languages = await client.ApiClient.GetLanguagesPaginatedJson(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(languages);
    }

    [Fact]
    public async Task GetLanguage()
    {
        var language = await client.ApiClient.GetLanguage(6513, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(language);
    }

    [Fact]
    public async Task GetLanguageJson()
    {
        var language = await client.ApiClient.GetLanguageJson(6513, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(language);
    }

    [Fact]
    public async Task SearchLanguages()
    {
        var languages = await client.ApiClient.SearchLanguages("tagalog", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(languages);
    }

    [Fact]
    public async Task SearchLanguagesPaginated()
    {
        var languages = await client.ApiClient.SearchLanguagesPaginated(1, "tagalog", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(languages);
    }

    [Fact]
    public async Task SearchLanguagesPaginatedJson()
    {
        var languages = await client.ApiClient.SearchLanguagesPaginatedJson(1, "tagalog", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(languages);
    }
}
