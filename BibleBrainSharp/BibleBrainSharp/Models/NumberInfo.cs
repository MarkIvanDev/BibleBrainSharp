using System;
using System.Collections.Generic;
using System.Text;
using BibleBrainSharp.Converters;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class NumberInfo
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

        [JsonProperty("numerals")]
        public Numeral[] Numerals { get; set; }

        public class Numeral
        {
            [JsonProperty("value")]
            public int? Value { get; set; }

            [JsonProperty("glyph")]
            public string Glyph { get; set; }

            [JsonProperty("numeral_written")]
            public string NumeralWritten { get; set; }
        }
    }

    public class NumberInfoResult
    {
        [JsonProperty("data")]
        public NumberInfo Data { get; set; }
    }
}
