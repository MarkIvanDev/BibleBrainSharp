namespace BibleBrainSharp.Tests
{
    public class CountryTests
    {
        [Fact]
        public async Task GetCountries()
        {
            var countries = await Client.ApiClient.GetCountries();
            Assert.NotEmpty(countries);
        }

        [Fact]
        public async Task GetCountriesPaginated()
        {
            var countries = await Client.ApiClient.GetCountriesPaginated(1);
            Assert.NotNull(countries);
        }

        [Fact]
        public async Task GetCountry()
        {
            var country = await Client.ApiClient.GetCountry("PH");
            Assert.NotNull(country);
        }

        [Fact]
        public async Task SearchCountries()
        {
            var countries = await Client.ApiClient.SearchCountries("south");
            Assert.NotEmpty(countries);
        }

        [Fact]
        public async Task SearchCountriesPaginated()
        {
            var countries = await Client.ApiClient.SearchCountriesPaginated(1, "south");
            Assert.NotNull(countries);
        }
    }
}
