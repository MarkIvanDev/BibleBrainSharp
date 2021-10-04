// MIT License

// Copyright(c) 2021 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
