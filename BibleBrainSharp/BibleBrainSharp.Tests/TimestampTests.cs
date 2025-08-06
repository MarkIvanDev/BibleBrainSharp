using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class TimestampTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task GetFilesetsWithTimestamps()
    {
        var filesets = await client.ApiClient.GetFilesetsWithTimestamps(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetFilesetsWithTimestampsJson()
    {
        var filesets = await client.ApiClient.GetFilesetsWithTimestampsJson(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(filesets);
    }

    [Fact]
    public async Task GetTimestamps()
    {
        var timestamps = await client.ApiClient.GetTimestamps("ENGKJVO1DA", "GEN", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(timestamps);
    }

    [Fact]
    public async Task GetTimestampsJson()
    {
        var timestamps = await client.ApiClient.GetTimestampsJson("ENGKJVO1DA", "GEN", 1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(timestamps);
    }
}
