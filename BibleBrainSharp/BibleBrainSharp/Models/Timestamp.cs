using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class TimestampsResult
    {
        public Timestamp[]? Data { get; set; }
    }

    public class Timestamp
    {
        public string? Book { get; set; }

        public string? Chapter { get; set; }

        [JsonProperty("verse_start")]
        public string? VerseStart { get; set; }

        [JsonProperty("timestamp")]
        public double? TimestampInfo { get; set; }
    }

    public class FilesetId
    {
        [JsonProperty("fileset_id")]
        public string? Id { get; set; }
    }
}
