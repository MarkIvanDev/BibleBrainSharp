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
    public class Verse
    {
        [JsonProperty("fileset_id")]
        public string FileSetId { get; set; }

        [JsonProperty("book_id")]
        public string BookId { get; set; }

        [JsonProperty("book_name")]
        public string BookName { get; set; }

        [JsonProperty("book_name_alt")]
        public string BookNameAlt { get; set; }

        [JsonProperty("chapter")]
        public int? Chapter { get; set; }

        [JsonProperty("chapter_alt")]
        public string ChapterAlt { get; set; }

        [JsonProperty("chapter_start")]
        public int? ChapterStart { get; set; }

        [JsonProperty("chapter_end")]
        public int? ChapterEnd { get; set; }

        [JsonProperty("verse_start")]
        public int? VerseStart { get; set; }

        [JsonProperty("verse_start_alt")]
        public string VerseStartAlt { get; set; }

        [JsonProperty("verse_end")]
        public int? VerseEnd { get; set; }

        [JsonProperty("verse_end_alt")]
        public string VerseEndAlt { get; set; }

        [JsonProperty("verse_text")]
        public string VerseText { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("bitrate")]
        public string Bitrate { get; set; }

        [JsonProperty("container")]
        public string Container { get; set; }

        [JsonProperty("multiple_mp3")]
        public bool? MultipleMp3 { get; set; }
    }

    public class VersesResult
    {
        [JsonProperty("data")]
        public Verse[] Data { get; set; }

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

                [JsonProperty("count")]
                public int Count { get; set; }

                [JsonProperty("per_page")]
                public int PerPage { get; set; }

                [JsonProperty("current_page")]
                public int CurrentPage { get; set; }

                [JsonProperty("total_pages")]
                public int TotalPages { get; set; }

                [JsonProperty("links")]
                public PageLinks Links { get; set; }

                public class PageLinks
                {
                    [JsonProperty("previous")]
                    public string Previous { get; set; }

                    [JsonProperty("next")]
                    public string Next { get; set; }
                }

            }

        }

    }

}
