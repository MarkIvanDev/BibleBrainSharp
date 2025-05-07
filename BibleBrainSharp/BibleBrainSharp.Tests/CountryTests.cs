using BibleBrainSharp.Tests.Fixtures;
using BibleBrainSharp.Tests.Generators;

namespace BibleBrainSharp.Tests;

public class CountryTests
{
    private readonly Client client;

    public CountryTests(Client client)
    {
        this.client = client;
    }

    [Fact]
    public async Task GetCountries()
    {
        var countries = await client.ApiClient.GetCountries();
        Assert.NotEmpty(countries);
    }

    [Fact]
    public async Task GetCountriesPaginated()
    {
        var countries = await client.ApiClient.GetCountriesPaginated(1);
        Assert.NotNull(countries);
    }

    [Theory]
    [ClassData(typeof(ISOA2Generator))]
    public async Task GetCountry(string countryId)
    {
        await Task.Delay(1000, TestContext.Current.CancellationToken);
        var country = await client.ApiClient.GetCountry(countryId);
        Assert.NotNull(country?.Data);
    }

    [Fact]
    public async Task SearchCountries()
    {
        var countries = await client.ApiClient.SearchCountries("south");
        Assert.NotEmpty(countries);
    }

    [Fact]
    public async Task SearchCountriesPaginated()
    {
        var countries = await client.ApiClient.SearchCountriesPaginated(1, "south");
        Assert.NotNull(countries);
    }
}
