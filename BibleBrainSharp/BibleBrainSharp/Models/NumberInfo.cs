// MIT License

// Copyright(c) 2021 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
