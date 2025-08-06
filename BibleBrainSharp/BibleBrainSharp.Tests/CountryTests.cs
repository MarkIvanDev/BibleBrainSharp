using BibleBrainSharp.Tests.Fixtures;
using BibleBrainSharp.Tests.Generators;

namespace BibleBrainSharp.Tests;

public class CountryTests(Client client)
{
    private readonly Client client = client;

    [Fact]
    public async Task GetCountries()
    {
        var countries = await client.ApiClient.GetCountries(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(countries);
    }

    [Fact]
    public async Task GetCountriesPaginated()
    {
        var countries = await client.ApiClient.GetCountriesPaginated(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(countries);
    }

    [Fact]
    public async Task GetCountriesPaginatedJson()
    {
        var countries = await client.ApiClient.GetCountriesPaginatedJson(1, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(countries);
    }

    [Theory]
    [ClassData(typeof(ISOA2Generator))]
    public async Task GetCountry(string countryId)
    {
        var country = await client.ApiClient.GetCountry(countryId, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(country?.Data);
    }

    [Theory]
    [ClassData(typeof(ISOA2Generator))]
    public async Task GetCountryJson(string countryId)
    {
        var country = await client.ApiClient.GetCountryJson(countryId, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(country);
    }

    [Fact]
    public async Task SearchCountries()
    {
        var countries = await client.ApiClient.SearchCountries("south", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotEmpty(countries);
    }

    [Fact]
    public async Task SearchCountriesPaginated()
    {
        var countries = await client.ApiClient.SearchCountriesPaginated(1, "south", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(countries);
    }

    [Fact]
    public async Task SearchCountriesPaginatedJson()
    {
        var countries = await client.ApiClient.SearchCountriesPaginatedJson(1, "south", cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(countries);
    }
}
