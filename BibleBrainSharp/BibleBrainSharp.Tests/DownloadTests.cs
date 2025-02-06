namespace BibleBrainSharp.Tests;

public class DownloadTests
{
    [Fact]
    public async Task GetDownloadableFilesets()
    {
        var filesets = await Client.ApiClient.GetDownloadableFilesets();
        Assert.NotEmpty(filesets);
    }

    [Fact]
    public async Task GetDownloadableFilesetsPaginated()
    {
        var filesets = await Client.ApiClient.GetDownloadableFilesetsPaginated(1);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetDownloadContent()
    {
        var contents = await Client.ApiClient.GetDownloadContent("ENGKJV", "MAT", 1);
        Assert.NotNull(contents);
    }
}
