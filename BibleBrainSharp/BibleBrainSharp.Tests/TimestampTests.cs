using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class TimestampTests
{
    private readonly Client client;

    public TimestampTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task GetFilesetsWithTimestamps()
    {
        var filesets = await client.ApiClient.GetFilesetsWithTimestamps(TestContext.Current.CancellationToken);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetTimestamps()
    {
        var timestamps = await client.ApiClient.GetTimestamps("ENGKJVO1DA", "GEN", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(timestamps);
    }
}
