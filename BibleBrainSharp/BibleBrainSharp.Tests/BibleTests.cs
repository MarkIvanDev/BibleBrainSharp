using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class BibleTests
{
    private readonly Client client;

    public BibleTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task GetBibles()
    {
        var bibles = await client.ApiClient.GetBibles(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task GetBiblesPaginated()
    {
        var bibles = await client.ApiClient.GetBiblesPaginated(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles?.Data);
    }

    [Fact]
    public async Task GetBible()
    {
        var kjvBible = await client.ApiClient.GetBible("ENGKJV", TestContext.Current.CancellationToken);
        Assert.NotNull(kjvBible);

        var esvBible = await client.ApiClient.GetBible("ENGESV", TestContext.Current.CancellationToken);
        Assert.NotNull(esvBible);
    }

    [Fact]
    public async Task GetBooks()
    {
        var kjvBooks = await client.ApiClient.GetBooks("ENGKJV", TestContext.Current.CancellationToken);
        Assert.NotNull(kjvBooks);

        var esvBooks = await client.ApiClient.GetBooks("ENGESV", TestContext.Current.CancellationToken);
        Assert.NotNull(esvBooks);
    }

    [Fact]
    public async Task GetCopyright()
    {
        var copyright = await client.ApiClient.GetCopyright("ENGKJV", TestContext.Current.CancellationToken);
        Assert.NotNull(copyright);
        Assert.NotEmpty(copyright);
    }

    [Fact]
    public async Task GetChapter()
    {
        var chapter = await client.ApiClient.GetChapter("ENGKJV", "GEN", 1, TestContext.Current.CancellationToken);
        Assert.NotNull(chapter);
    }

    [Fact]
    public async Task GetDefaultBibles()
    {
        var defaultBibles = await client.ApiClient.GetDefaultBibles(TestContext.Current.CancellationToken);
        Assert.NotNull(defaultBibles);
        Assert.True(defaultBibles?.Count > 0);
    }

    [Fact]
    public async Task GetMediaTypes()
    {
        var mediaTypes = await client.ApiClient.GetMediaTypes(TestContext.Current.CancellationToken);
        Assert.NotNull(mediaTypes);
        Assert.True(mediaTypes?.Count > 0);
    }

    [Fact]
    public async Task GetVersesByLanguage()
    {
        var verses = await client.ApiClient.GetVersesByLanguage("eng", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(verses);
    }

    [Fact]
    public async Task GetVersesByLanguagePaginated()
    {
        var verses = await client.ApiClient.GetVersesByLanguagePaginated(1, "eng", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(verses);
    }

    [Fact]
    public async Task GetVersesByVersion()
    {
        var verses = await client.ApiClient.GetVersesByVersion("ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(verses);
    }

    [Fact]
    public async Task GetVersesByVersionPaginated()
    {
        var verses = await client.ApiClient.GetVersesByVersionPaginated(1, "ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(verses);
    }

    [Fact]
    public async Task SearchBiblesByVersion()
    {
        var bibles = await client.ApiClient.SearchBiblesByVersion("KJV", TestContext.Current.CancellationToken);
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task SearchBiblesByVersionPaginated()
    {
        var bibles = await client.ApiClient.SearchBiblesByVersionPaginated(1, "KJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task SearchBibles()
    {
        var bibles = await client.ApiClient.SearchBibles("king", TestContext.Current.CancellationToken);
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task SearchBiblesPaginated()
    {
        var bibles = await client.ApiClient.SearchBiblesPaginated(1, "king", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task GetVerseInfo()
    {
        var verses = await client.ApiClient.GetVerseInfo("ENGKJV", "MAT", 1, TestContext.Current.CancellationToken);
        Assert.NotNull(verses);
    }

}
