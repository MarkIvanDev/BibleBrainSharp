namespace BibleBrainSharp.Tests
{
    public class NumberTests
    {
        [Fact]
        public async Task GetNumbers()
        {
            var numbers = await Client.ApiClient.GetNumbers();
            Assert.NotNull(numbers);
        }

        [Fact]
        public async Task GetNumber()
        {
            var number = await Client.ApiClient.GetNumber("thai");
            Assert.NotNull(number);
        }

    }
}
