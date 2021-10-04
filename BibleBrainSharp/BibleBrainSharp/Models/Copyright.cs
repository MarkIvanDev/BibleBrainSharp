using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Copyright
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public MediaType? Type { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        public class CopyrightInfo
        {
            [JsonProperty("copyright_date")]
            public string Date { get; set; }

            [JsonProperty("copyright")]
            public string Text { get; set; }

            [JsonProperty("copyright_description")]
            public string Description { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }

            [JsonProperty("open_access")]
            public int? OpenAccess { get; set; }

            [JsonProperty("organizations")]
            public Organization[] Organizations { get; set; }
        }
    }

}
