using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class BibleTests(Client client)
{
    private readonly Client client = client;

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
    public async Task GetBiblesPaginatedJson()
    {
        var bibles = await client.ApiClient.GetBiblesPaginatedJson(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task GetBible()
    {
        var kjvBible = await client.ApiClient.GetBible("ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(kjvBible);

        var esvBible = await client.ApiClient.GetBible("ENGESV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(esvBible);
    }

    [Fact]
    public async Task GetBibleJson()
    {
        var kjvBible = await client.ApiClient.GetBibleJson("ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(kjvBible);

        var esvBible = await client.ApiClient.GetBibleJson("ENGESV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(esvBible);
    }

    [Fact]
    public async Task GetBooks()
    {
        var kjvBooks = await client.ApiClient.GetBooks("ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(kjvBooks);

        var esvBooks = await client.ApiClient.GetBooks("ENGESV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(esvBooks);
    }

    [Fact]
    public async Task GetBooksJson()
    {
        var kjvBooks = await client.ApiClient.GetBooksJson("ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(kjvBooks);

        var esvBooks = await client.ApiClient.GetBooksJson("ENGESV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(esvBooks);
    }

    [Fact]
    public async Task GetCopyright()
    {
        var copyright = await client.ApiClient.GetCopyright("ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(copyright);
        Assert.NotEmpty(copyright);
    }

    [Fact]
    public async Task GetCopyrightJson()
    {
        var copyright = await client.ApiClient.GetCopyrightJson("ENGKJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(copyright);
    }

    [Fact]
    public async Task GetChapter()
    {
        var chapter = await client.ApiClient.GetChapter("ENGKJV", "GEN", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(chapter);
    }

    [Fact]
    public async Task GetChapterJson()
    {
        var chapter = await client.ApiClient.GetChapterJson("ENGKJV", "GEN", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(chapter);
    }

    [Fact]
    public async Task GetDefaultBibles()
    {
        var defaultBibles = await client.ApiClient.GetDefaultBibles(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(defaultBibles);
        Assert.True(defaultBibles?.Count > 0);
    }

    [Fact]
    public async Task GetDefaultBiblesJson()
    {
        var defaultBibles = await client.ApiClient.GetDefaultBiblesJson(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(defaultBibles);
    }

    [Fact]
    public async Task GetMediaTypes()
    {
        var mediaTypes = await client.ApiClient.GetMediaTypes(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(mediaTypes);
        Assert.True(mediaTypes?.Count > 0);
    }

    [Fact]
    public async Task GetMediaTypesJson()
    {
        var mediaTypes = await client.ApiClient.GetMediaTypesJson(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(mediaTypes);
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
    public async Task GetVersesByLanguagePaginatedJson()
    {
        var verses = await client.ApiClient.GetVersesByLanguagePaginatedJson(1, "eng", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
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
    public async Task GetVersesByVersionPaginatedJson()
    {
        var verses = await client.ApiClient.GetVersesByVersionPaginatedJson(1, "ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(verses);
    }

    [Fact]
    public async Task SearchBiblesByVersion()
    {
        var bibles = await client.ApiClient.SearchBiblesByVersion("KJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task SearchBiblesByVersionPaginated()
    {
        var bibles = await client.ApiClient.SearchBiblesByVersionPaginated(1, "KJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task SearchBiblesByVersionPaginatedJson()
    {
        var bibles = await client.ApiClient.SearchBiblesByVersionPaginatedJson(1, "KJV", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task SearchBibles()
    {
        var bibles = await client.ApiClient.SearchBibles("king", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task SearchBiblesPaginated()
    {
        var bibles = await client.ApiClient.SearchBiblesPaginated(1, "king", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task SearchBiblesPaginatedJson()
    {
        var bibles = await client.ApiClient.SearchBiblesPaginatedJson(1, "king", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task GetVerseInfo()
    {
        var verses = await client.ApiClient.GetVerseInfo("ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(verses);
    }

    [Fact]
    public async Task GetVerseInfoJson()
    {
        var verses = await client.ApiClient.GetVerseInfoJson("ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(verses);
    }

}
