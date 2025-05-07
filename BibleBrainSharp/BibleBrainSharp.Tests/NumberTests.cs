using BibleBrainSharp.Tests.Fixtures;

namespace BibleBrainSharp.Tests;

public class NumberTests
{
    private readonly Client client;

    public NumberTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task GetNumbers()
    {
        var numbers = await client.ApiClient.GetNumbers();
        Assert.NotNull(numbers);
    }

    [Fact]
    public async Task GetNumber()
    {
        var number = await client.ApiClient.GetNumber("thai");
        Assert.NotNull(number);
    }

}
