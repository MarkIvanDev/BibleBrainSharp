using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BibleBrainSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MediaType
    {
        [EnumMember(Value = "text_plain")]
        TextPlain,

        [EnumMember(Value = "text_format")]
        TextFormat,

        [EnumMember(Value = "text_usx")]
        TextUsx,

        [EnumMember(Value = "text_html")]
        TextHtml,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "audio_drama")]
        AudioDrama,

        [EnumMember(Value = "audio_stream")]
        AudioStream,

        [EnumMember(Value = "audio_drama_stream")]
        AudioDramaStream,

        [EnumMember(Value = "video_stream")]
        VideoStream
    }

    public static class MediaTypeExtensions
    {
        public static string GetEnumMemberValue(this MediaType mediaType)
        {
            return typeof(MediaType)
                .GetMember(mediaType.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<EnumMemberAttribute>()?
                .Value;
        }
    }
}
