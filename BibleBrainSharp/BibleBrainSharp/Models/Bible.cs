using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{

    public class Bible
    {
        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vname")]
        public string Vname { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("autonym")]
        public string Autonym { get; set; }

        [JsonProperty("language_id")]
        public int LanguageId { get; set; }

        [JsonProperty("iso")]
        public string ISO { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("filesets")]
        public FileSets FileSets { get; set; }

    }

    public class BiblesResult
    {
        [JsonProperty("data")]
        public Bible[] Data { get; set; }

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

                [JsonProperty("per_page")]
                public int PerPage { get; set; }

                [JsonProperty("current_page")]
                public int CurrentPage { get; set; }

                [JsonProperty("last_page")]
                public int LastPage { get; set; }

                [JsonProperty("next_page_url")]
                public string Next { get; set; }

                [JsonProperty("prev_page_url")]
                public object Previous { get; set; }

                [JsonProperty("from")]
                public int From { get; set; }

                [JsonProperty("to")]
                public int To { get; set; }
            }

        }

    }

}
