namespace BibleBrainSharp.Tests;

public class AlphabetTests
{

    [Fact]
    public async Task GetAlphabets()
    {
        var alphabets = await Client.ApiClient.GetAlphabets();
        Assert.NotNull(alphabets);
    }

    [Fact]
    public async Task GetAlphabet()
    {
        var alphabet = await Client.ApiClient.GetAlphabet("Latn");
        Assert.NotNull(alphabet);
    }
}