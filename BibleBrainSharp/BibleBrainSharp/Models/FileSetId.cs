using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class FileSetId
    {
        [JsonProperty("fileset_id")]
        public string Id { get; set; }
    }

}
