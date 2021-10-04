using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class DefaultBible
    {
        [JsonProperty("audio")]
        public string Audio { get; set; }

        [JsonProperty("video")]
        public string Video { get; set; }
    }

}
