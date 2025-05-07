using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class LanguageTests
{
    private readonly Client client;

    public LanguageTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task GetLanguages()
    {
        var languages = await client.ApiClient.GetLanguages();
        Assert.NotEmpty(languages);
    }

    [Fact]
    public async Task GetLanguagesPaginated()
    {
        var languages = await client.ApiClient.GetLanguagesPaginated(1);
        Assert.NotNull(languages);
    }

    [Fact]
    public async Task GetLanguage()
    {
        var language = await client.ApiClient.GetLanguage(6513);
        Assert.NotNull(language);
    }

    [Fact]
    public async Task SearchLanguages()
    {
        var languages = await client.ApiClient.SearchLanguages("tagalog");
        Assert.NotEmpty(languages);
    }

    [Fact]
    public async Task SearchLanguagesPaginated()
    {
        var languages = await client.ApiClient.SearchLanguagesPaginated(1, "tagalog");
        Assert.NotNull(languages);
    }
}
