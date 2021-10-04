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
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Search
    {
        [JsonProperty("audio_filesets")]
        public AudioFileSet[] AudioFileSets { get; set; }

        [JsonProperty("verses")]
        public VersesResult Verses { get; set; }

        public class AudioFileSet
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("asset_id")]
            public string AssetId { get; set; }

            [JsonProperty("set_type_code")]
            public MediaType? SetTypeCode { get; set; }

            [JsonProperty("set_size_code")]
            public string SetSizeCode { get; set; }

            [JsonProperty("laravel_through_key")]
            public string LaravelThroughKey { get; set; }

            [JsonProperty("meta")]
            public Metadata[] Meta { get; set; }

            public class Metadata
            {
                [JsonProperty("hash_id")]
                public string HashId { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("iso")]
                public string ISO { get; set; }

                [JsonProperty("language_id")]
                public int LanguageId { get; set; }
            }

        }
    }
}
