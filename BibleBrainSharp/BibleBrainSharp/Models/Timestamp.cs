using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Timestamp
    {
        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("chapter")]
        public string Chapter { get; set; }

        [JsonProperty("verse_start")]
        public string VerseStart { get; set; }

        [JsonProperty("timestamp")]
        public double? Position { get; set; }
    }

    public class TimestampsResult
    {
        [JsonProperty("data")]
        public Timestamp[] Data { get; set; }
    }
}
