namespace BibleBrainSharp.Tests
{
    public class TimestampTests
    {
        [Fact]
        public async Task GetFilesetsWithTimestamps()
        {
            var filesets = await Client.ApiClient.GetFilesetsWithTimestamps();
            Assert.NotNull(filesets);
        }

        [Fact]
        public async Task GetTimestamps()
        {
            var timestamps = await Client.ApiClient.GetTimestamps("ENGKJVO1DA", "GEN", 1);
            Assert.NotNull(timestamps);
        }
    }
}
