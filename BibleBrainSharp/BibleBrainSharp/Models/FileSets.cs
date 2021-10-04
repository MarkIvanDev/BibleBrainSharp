using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class FileSets
    {
        [JsonProperty("dbp-prod")]
        public FileSet[] Prod { get; set; }

        [JsonProperty("dbp-vid")]
        public FileSet[] Vid { get; set; }


        public class FileSet
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("size")]
            public string Size { get; set; }

            [JsonProperty("stock_no")]
            public string StockNo { get; set; }

            [JsonProperty("volume")]
            public string Volume { get; set; }
        }
    }
}
