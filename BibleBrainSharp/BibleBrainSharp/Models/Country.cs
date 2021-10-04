using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("continent_code")]
        public string ContinentCode { get; set; }

        [JsonProperty("codes")]
        public CountryCodes Codes { get; set; }

    }

    public class CountriesResult
    {
        [JsonProperty("data")]
        public Country[] Data { get; set; }

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
