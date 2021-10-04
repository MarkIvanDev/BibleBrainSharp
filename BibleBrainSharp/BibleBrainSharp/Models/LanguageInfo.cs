using System;
using System.Collections.Generic;
using System.Text;
using BibleBrainSharp.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BibleBrainSharp.Models
{
    public class LanguageInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("autonym")]
        public string Autonym { get; set; }

        [JsonProperty("glotto_id")]
        public string GlottoId { get; set; }

        [JsonProperty("iso")]
        public string ISO { get; set; }

        [JsonProperty("maps")]
        public string Maps { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("population")]
        public int? Population { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("alternativeNames")]
        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<int, string>))]
        public Dictionary<int, string> AlternativeNames { get; set; }

        [JsonProperty("classifications")]
        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
        public Dictionary<string, string> Classifications { get; set; }

        [JsonProperty("bibles")]
        public Bible[] Bibles { get; set; }

        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }

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

            [JsonProperty("translations")]
            public Translation[] Translations { get; set; }

            [JsonProperty("filesets")]
            public FileSet[] FileSets { get; set; }

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
            }
        
            public class FileSet
            {
                [JsonProperty("id")]
                public int Id { get; set; }

                [JsonProperty("asset_id")]
                public string AssetId { get; set; }

                [JsonProperty("set_type_code")]
                public string SetTypeCode { get; set; }

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

        public class Resource
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("language_id")]
            public int LanguageId { get; set; }

            [JsonProperty("iso")]
            public string ISO { get; set; }

            [JsonProperty("organization_id")]
            public int OrganizationId { get; set; }

            [JsonProperty("source_id")]
            public string SourceId { get; set; }

            [JsonProperty("cover")]
            public string Cover { get; set; }

            [JsonProperty("cover_thumbnail")]
            public string CoverThumbnail { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("translations")]
            public Translation[] Translations { get; set; }

            [JsonProperty("links")]
            public Link[] Links { get; set; }

            public class Translation
            {
                [JsonProperty("language_id")]
                public int LanguageId { get; set; }

                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }
            }

            public class Link
            {
                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("type")]
                public string Type { get; set; }

                [JsonProperty("url")]
                public string Url { get; set; }
            }
        }
    }

    public class LanguageInfoResult
    {
        [JsonProperty("data")]
        public LanguageInfo Data { get; set; }
    }

}
