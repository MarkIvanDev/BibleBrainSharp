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

    public class BibleInfo
    {
        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("alphabet")]
        public AlphabetInfo Alphabet { get; set; }

        [JsonProperty("mark")]
        public string Mark { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("vname")]
        public string Vname { get; set; }

        [JsonProperty("vdescription")]
        public string Vdescription { get; set; }

        [JsonProperty("publishers")]
        public Organization[] Publishers { get; set; }

        [JsonProperty("providers")]
        public Organization[] Providers { get; set; }

        [JsonProperty("equivalents")]
        public Equivalent[] Equivalents { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("language_id")]
        public int LanguageId { get; set; }

        [JsonProperty("iso")]
        public string ISO { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("books")]
        public Book[] Books { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("filesets")]
        public FileSets FileSets { get; set; }

        [JsonProperty("fonts")]
        public Font Fonts { get; set; }

        public class AlphabetInfo
        {
            [JsonProperty("script")]
            public string Script { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("direction")]
            public AlphabetDirection? Direction { get; set; }

            [JsonProperty("unicode")]
            public bool? Unicode { get; set; }

            [JsonProperty("requires_font")]
            public bool? RequiresFont { get; set; }
        }

        public class Equivalent
        {
            [JsonProperty("bible_id")]
            public string BibleId { get; set; }

            [JsonProperty("equivalent_id")]
            public string EquivalentId { get; set; }

            [JsonProperty("organization_id")]
            public int OrganizationId { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("site")]
            public string Site { get; set; }

            [JsonProperty("suffix")]
            public string Suffix { get; set; }
        }

        public class Book
        {
            [JsonProperty("book_id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("name_short")]
            public string ShortName { get; set; }

            [JsonProperty("chapters")]
            public int[] Chapters { get; set; }

            [JsonProperty("testament")]
            public BookTestament? Testament { get; set; }
        }

        public class Link
        {
            [JsonProperty("bible_id")]
            public string BibleId { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("provider")]
            public string Provider { get; set; }

            [JsonProperty("organization_id")]
            public int OrganizationId { get; set; }
        }

        public class Font
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("data")]
            public string Data { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }
    }

    public class BibleInfoResult
    {
        [JsonProperty("data")]
        public BibleInfo Data { get; set; }
    }

}
