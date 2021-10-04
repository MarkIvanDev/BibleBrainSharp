using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BibleBrainSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BibleVersification
    {
        Protestant,
        Luther,
        Synodal,
        German,
        KJVA,
        Vulgate,
        LXX,
        Orthodox,
        NRSVA,
        Catholic,
        Finnish
    }
}
