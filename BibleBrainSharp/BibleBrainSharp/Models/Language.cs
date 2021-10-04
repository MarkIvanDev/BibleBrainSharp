using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Language
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("glotto_id")]
        public string GlottoId { get; set; }

        [JsonProperty("iso")]
        public string ISO { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("autonym")]
        public string Autonym { get; set; }

        [JsonProperty("bibles")]
        public int? Bibles { get; set; }

        [JsonProperty("filesets")]
        public int? FileSets { get; set; }
    }
    
    public class LanguagesResult
    {
        [JsonProperty("data")]
        public Language[] Data { get; set; }

        [JsonProperty("meta")]
        public Metadata Meta { get; set; }

        public class Metadata
        {
            [JsonProperty("pagination")]
            public PaginationInfo Pagination { get; set; }

            public class PaginationInfo
            {
                [JsonProperty("total")]
                public int Total { get; set; }

                [JsonProperty("count")]
                public int Count { get; set; }

                [JsonProperty("per_page")]
                public int PerPage { get; set; }

                [JsonProperty("current_page")]
                public int CurrentPage { get; set; }

                [JsonProperty("total_pages")]
                public int TotalPages { get; set; }

                [JsonProperty("links")]
                public PageLinks Links { get; set; }

                public class PageLinks
                {
                    [JsonProperty("previous")]
                    public string Previous { get; set; }

                    [JsonProperty("next")]
                    public string Next { get; set; }

                }
            }
        }
    }

}
