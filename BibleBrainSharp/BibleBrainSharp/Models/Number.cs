using System.Collections.Generic;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class NumbersResult
    {
        public Number[]? Data { get; set; }
    }

    public class Number
    {
        public string? Id { get; set; }

        public string? Description { get; set; }

        public string? Notes { get; set; }

        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
        public Dictionary<string, string>? Alphabets { get; set; }
    }

    public class NumberInfoResult
    {
        public NumberInfo? Data { get; set; }
    }

    public class NumberInfo
    {
        public string? Id { get; set; }

        public string? Description { get; set; }

        public string? Notes { get; set; }

        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
        public Dictionary<string, string>? Alphabets { get; set; }

        public NumberInfoNumeral[]? Numerals { get; set; }
    }

    public class NumberInfoNumeral
    {
        public int? Value { get; set; }

        public string? Glyph { get; set; }

        [JsonProperty("numeral_written")]
        public string? NumeralWritten { get; set; }
    }

}
