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

    public class CountryInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        [JsonProperty("continent_code")]
        public string ContinentCode { get; set; }

        [JsonProperty("maps")]
        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, MapInfo>))]
        public Dictionary<string, MapInfo> Maps { get; set; }

        [JsonProperty("wfb")]
        public int? Wfb { get; set; }

        [JsonProperty("ethnologue")]
        public int? Ethnologue { get; set; }

        [JsonProperty("languages")]
        public Language[] Languages { get; set; }

        [JsonProperty("codes")]
        public CountryCodes Codes { get; set; }


        public class MapInfo
        {
            [JsonProperty("thumbnail_url")]
            public string ThumbnailUrl { get; set; }

            [JsonProperty("map_url")]
            public string MapUrl { get; set; }
        }

        public class Language
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("iso")]
            public string ISO { get; set; }

            [JsonProperty("bibles")]
            [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
            public Dictionary<string, string> Bibles { get; set; }
        }

    }

    public class CountryInfoResult
    {
        [JsonProperty("data")]
        public CountryInfo Data { get; set; }
    }

}
