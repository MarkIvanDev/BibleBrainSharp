using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BibleBrainSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlphabetDirection
    {
        [EnumMember(Value = "")]
        Unknown,
        LTR,
        RTL
    }
}
