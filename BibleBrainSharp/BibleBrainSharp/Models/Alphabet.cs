using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{

    public class Alphabet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("direction")]
        public AlphabetDirection Direction { get; set; }
    }

    public class AlphabetsResult
    {
        [JsonProperty("data")]
        public Alphabet[] Data { get; set; }

    }

}
