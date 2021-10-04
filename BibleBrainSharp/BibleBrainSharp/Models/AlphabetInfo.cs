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
using Newtonsoft.Json.Converters;

namespace BibleBrainSharp.Models
{

    public class AlphabetInfo
    {
        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unicode_pdf")]
        public string UnicodePdf { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("white_space")]
        public string Whitespace { get; set; }

        [JsonProperty("open_type_tag")]
        public string OpenTypeTag { get; set; }

        [JsonProperty("complex_positioning")]
        public bool? ComplexPositioning { get; set; }

        [JsonProperty("requires_font")]
        public bool? RequiresFont { get; set; }

        [JsonProperty("unicode")]
        public bool? Unicode { get; set; }

        [JsonProperty("diacritics")]
        public bool? Diacritics { get; set; }

        [JsonProperty("contextual_forms")]
        public bool? ContextualForms { get; set; }

        [JsonProperty("reordering")]
        public bool? Reordering { get; set; }

        [JsonProperty("case")]
        public bool? Case { get; set; }

        [JsonProperty("split_graphs")]
        public bool? SplitGraphs { get; set; }

        [JsonProperty("status")]
        public AlphabetStatus? Status { get; set; }

        [JsonProperty("baseline")]
        public AlphabetBaseline? Baseline { get; set; }

        [JsonProperty("ligatures")]
        public AlphabetLigature? Ligatures { get; set; }

        [JsonProperty("direction")]
        public AlphabetDirection? Direction { get; set; }

        [JsonProperty("direction_notes")]
        public string DirectionNotes { get; set; }

        [JsonProperty("sample")]
        public string Sample { get; set; }

        [JsonProperty("sample_img")]
        public string SampleImg { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fonts")]
        public Font[] Fonts { get; set; }

        [JsonProperty("languages")]
        public Language[] Languages { get; set; }

        [JsonProperty("bibles")]
        public Bible[] Bibles { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AlphabetStatus
        {
            Current,
            Historical,
            Fictional,
            Unclear
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AlphabetBaseline
        {
            Hanging,
            Centered,
            Bottom,
            Vertical
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AlphabetLigature
        {
            None,
            Required,
            Optional
        }

        public class Font
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("fontName")]
            public string FontName { get; set; }

            [JsonProperty("fontFileName")]
            public string FontFileName { get; set; }

            [JsonProperty("fontWeight")]
            public int? FontWeight { get; set; }

            [JsonProperty("copyright")]
            public string Copyright { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("italic")]
            public bool? Italic { get; set; }
        }


        public class Language
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("glotto_id")]
            public string GlottoId { get; set; }

            [JsonProperty("iso")]
            public string ISO { get; set; }

            [JsonProperty("iso2B")]
            public string ISO2B { get; set; }

            [JsonProperty("iso2T")]
            public string ISO2T { get; set; }

            [JsonProperty("iso1")]
            public string ISO1 { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("maps")]
            public string Maps { get; set; }

            [JsonProperty("development")]
            public string Development { get; set; }

            [JsonProperty("use")]
            public string Use { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("area")]
            public string Area { get; set; }

            [JsonProperty("population")]
            public int? Population { get; set; }

            [JsonProperty("population_notes")]
            public string PopulationNotes { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("typology")]
            public string Typology { get; set; }

            [JsonProperty("writing")]
            public string Writing { get; set; }

            [JsonProperty("latitude")]
            public double? Latitude { get; set; }

            [JsonProperty("longitude")]
            public double? Longitude { get; set; }

            [JsonProperty("status_id")]
            public string StatusId { get; set; }

            [JsonProperty("country_id")]
            public string CountryId { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }

            [JsonProperty("pivot")]
            public PivotInfo Pivot { get; set; }

            public class PivotInfo
            {
                [JsonProperty("script_id")]
                public string ScriptId { get; set; }

                [JsonProperty("language_id")]
                public int LanguageId { get; set; }
            }

        }

        public class Bible
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("language_id")]
            public int LanguageId { get; set; }

            [JsonProperty("versification")]
            public BibleVersification? Versification { get; set; }

            [JsonProperty("numeral_system_id")]
            public string NumeralSystemId { get; set; }

            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("scope")]
            public string Scope { get; set; }

            [JsonProperty("script")]
            public string Script { get; set; }

            [JsonProperty("derived")]
            public string Derived { get; set; }

            [JsonProperty("copyright")]
            public string Copyright { get; set; }

            [JsonProperty("reviewed")]
            public int? Reviewed { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("current_translation")]
            public Translation CurrentTranslation { get; set; }

            public class Translation
            {
                [JsonProperty("language_id")]
                public int LanguageId { get; set; }

                [JsonProperty("bible_id")]
                public string BibleId { get; set; }

                [JsonProperty("vernacular")]
                public int? Vernacular { get; set; }

                [JsonProperty("vernacular_trade")]
                public int? VernacularTrade { get; set; }

                [JsonProperty("name")]
                public string Name { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("background")]
                public string Background { get; set; }
            }
        }

    }

    public class AlphabetInfoResult
    {
        [JsonProperty("data")]
        public AlphabetInfo Data { get; set; }
    }

}
