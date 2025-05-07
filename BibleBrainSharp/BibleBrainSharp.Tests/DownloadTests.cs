using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class DownloadTests
{
    private readonly Client client;

    public DownloadTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task GetDownloadableFilesets()
    {
        var filesets = await client.ApiClient.GetDownloadableFilesets();
        Assert.NotEmpty(filesets);
    }

    [Fact]
    public async Task GetDownloadableFilesetsPaginated()
    {
        var filesets = await client.ApiClient.GetDownloadableFilesetsPaginated(1);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetDownloadContent()
    {
        var contents = await client.ApiClient.GetDownloadContent("ENGKJV", "MAT", 1);
        Assert.NotNull(contents);
    }
}
