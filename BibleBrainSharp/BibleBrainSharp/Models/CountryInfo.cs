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
