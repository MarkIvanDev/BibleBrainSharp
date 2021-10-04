using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class CountryCodes
    {
        [JsonProperty("fips")]
        public string FIPS { get; set; }

        [JsonProperty("iso_a3")]
        public string ISOA3 { get; set; }

        [JsonProperty("iso_a2")]
        public string ISOA2 { get; set; }
    }
}
