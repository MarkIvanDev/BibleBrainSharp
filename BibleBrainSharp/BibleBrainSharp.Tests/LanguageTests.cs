namespace BibleBrainSharp.Tests
{
    public class LanguageTests
    {
        [Fact]
        public async Task GetLanguages()
        {
            var languages = await Client.ApiClient.GetLanguages();
            Assert.NotEmpty(languages);
        }

        [Fact]
        public async Task GetLanguagesPaginated()
        {
            var languages = await Client.ApiClient.GetLanguagesPaginated(1);
            Assert.NotNull(languages);
        }

        [Fact]
        public async Task GetLanguage()
        {
            var language = await Client.ApiClient.GetLanguage(6513);
            Assert.NotNull(language);
        }

        [Fact]
        public async Task SearchLanguages()
        {
            var languages = await Client.ApiClient.SearchLanguages("tagalog");
            Assert.NotEmpty(languages);
        }

        [Fact]
        public async Task SearchLanguagesPaginated()
        {
            var languages = await Client.ApiClient.SearchLanguagesPaginated(1, "tagalog");
            Assert.NotNull(languages);
        }
    }
}
