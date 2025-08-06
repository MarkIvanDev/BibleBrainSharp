using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class DownloadTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task GetDownloadableFilesets()
    {
        var filesets = await client.ApiClient.GetDownloadableFilesets(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(filesets);
    }

    [Fact]
    public async Task GetDownloadableFilesetsPaginated()
    {
        var filesets = await client.ApiClient.GetDownloadableFilesetsPaginated(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetDownloadableFilesetsPaginatedJson()
    {
        var filesets = await client.ApiClient.GetDownloadableFilesetsPaginatedJson(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetDownloadContent()
    {
        var contents = await client.ApiClient.GetDownloadContent("ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(contents);
    }

    [Fact]
    public async Task GetDownloadContentJson()
    {
        var contents = await client.ApiClient.GetDownloadContentJson("ENGKJV", "MAT", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(contents);
    }
}
