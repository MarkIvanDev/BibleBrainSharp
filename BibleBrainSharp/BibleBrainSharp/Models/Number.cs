using System;
using System.Collections.Generic;
using System.Text;
using BibleBrainSharp.Converters;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{

    public class Number
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("alphabets")]
        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
        public Dictionary<string, string> Alphabets { get; set; }
    }

    public class NumbersResult
    {
        [JsonProperty("data")]
        public Number[] Data { get; set; }
    }

}
