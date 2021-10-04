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
