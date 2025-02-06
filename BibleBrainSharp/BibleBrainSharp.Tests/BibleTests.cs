namespace BibleBrainSharp.Tests;

public class BibleTests
{
    [Fact]
    public async Task GetBibles()
    {
        var bibles = await Client.ApiClient.GetBibles();
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task GetBiblesPaginated()
    {
        var bibles = await Client.ApiClient.GetBiblesPaginated(1);
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task GetBible()
    {
        var kjvBible = await Client.ApiClient.GetBible("ENGKJV");
        Assert.NotNull(kjvBible);

        var esvBible = await Client.ApiClient.GetBible("ENGESV");
        Assert.NotNull(esvBible);
    }

    [Fact]
    public async Task GetBooks()
    {
        var kjvBooks = await Client.ApiClient.GetBooks("ENGKJV");
        Assert.NotNull(kjvBooks);

        var esvBooks = await Client.ApiClient.GetBooks("ENGESV");
        Assert.NotNull(esvBooks);
    }

    [Fact]
    public async Task GetCopyright()
    {
        var copyright = await Client.ApiClient.GetCopyright("ENGKJV");
        Assert.NotEmpty(copyright);
    }

    [Fact]
    public async Task GetChapter()
    {
        var chapter = await Client.ApiClient.GetChapter("ENGKJV", "GEN", 1);
        Assert.NotNull(chapter);
    }

    [Fact]
    public async Task GetDefaultBibles()
    {
        var defaultBibles = await Client.ApiClient.GetDefaultBibles();
        Assert.NotNull(defaultBibles);
        Assert.True(defaultBibles?.Count > 0);
    }

    [Fact]
    public async Task GetMediaTypes()
    {
        var mediaTypes = await Client.ApiClient.GetMediaTypes();
        Assert.NotNull(mediaTypes);
        Assert.True(mediaTypes?.Count > 0);
    }

    [Fact]
    public async Task GetVersesByLanguage()
    {
        var verses = await Client.ApiClient.GetVersesByLanguage("eng", "MAT", 1);
        Assert.NotEmpty(verses);
    }

    [Fact]
    public async Task GetVersesByLanguagePaginated()
    {
        var verses = await Client.ApiClient.GetVersesByLanguagePaginated(1, "eng", "MAT", 1);
        Assert.NotNull(verses);
    }

    [Fact]
    public async Task GetVersesByVersion()
    {
        var verses = await Client.ApiClient.GetVersesByVersion("ENGKJV", "MAT", 1);
        Assert.NotEmpty(verses);
    }

    [Fact]
    public async Task GetVersesByVersionPaginated()
    {
        var verses = await Client.ApiClient.GetVersesByVersionPaginated(1, "ENGKJV", "MAT", 1);
        Assert.NotNull(verses);
    }

    [Fact]
    public async Task SearchBiblesByVersion()
    {
        var bibles = await Client.ApiClient.SearchBiblesByVersion("KJV");
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task SearchBiblesByVersionPaginated()
    {
        var bibles = await Client.ApiClient.SearchBiblesByVersionPaginated(1, "KJV");
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task SearchBibles()
    {
        var bibles = await Client.ApiClient.SearchBibles("king");
        Assert.NotEmpty(bibles);
    }

    [Fact]
    public async Task SearchBiblesPaginated()
    {
        var bibles = await Client.ApiClient.SearchBiblesPaginated(1, "king");
        Assert.NotNull(bibles);
    }

    [Fact]
    public async Task GetVerseInfo()
    {
        var verses = await Client.ApiClient.GetVerseInfo("ENGKJV", "MAT", 1);
        Assert.NotNull(verses);
    }

}
