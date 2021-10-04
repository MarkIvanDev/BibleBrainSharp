using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Search
    {
        [JsonProperty("audio_filesets")]
        public AudioFileSet[] AudioFileSets { get; set; }

        [JsonProperty("verses")]
        public VersesResult Verses { get; set; }

        public class AudioFileSet
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("asset_id")]
            public string AssetId { get; set; }

            [JsonProperty("set_type_code")]
            public MediaType? SetTypeCode { get; set; }

            [JsonProperty("set_size_code")]
            public string SetSizeCode { get; set; }

            [JsonProperty("laravel_through_key")]
            public string LaravelThroughKey { get; set; }

            [JsonProperty("meta")]
            public Metadata[] Meta { get; set; }

            public class Metadata
            {
                [JsonProperty("hash_id")]
                public string HashId { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iso")]
                public string ISO { get; set; }

                [JsonProperty("language_id")]
                public int LanguageId { get; set; }
            }

        }
    }
}
