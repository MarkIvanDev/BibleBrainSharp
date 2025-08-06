using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class NumberTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task GetNumbers()
    {
        var numbers = await client.ApiClient.GetNumbers(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(numbers);
    }

    [Fact]
    public async Task GetNumbersJson()
    {
        var numbers = await client.ApiClient.GetNumbersJson(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(numbers);
    }

    [Fact]
    public async Task GetNumber()
    {
        var number = await client.ApiClient.GetNumber("thai", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(number);
    }

    [Fact]
    public async Task GetNumberJson()
    {
        var number = await client.ApiClient.GetNumberJson("thai", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(number);
    }

}
