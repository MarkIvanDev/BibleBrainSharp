using System.Collections.Generic;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class LanguagesResult
    {
        public Language[]? Data { get; set; }

        public LanguagesResultMetadata? Meta { get; set; }
    }

    public class Language
    {
        public int? Id { get; set; }

        [JsonProperty("glotto_id")]
        public string? GlottoId { get; set; }

        public string? Iso { get; set; }

        public string? Name { get; set; }

        public string? Autonym { get; set; }

        public int? Bibles { get; set; }

        public int? Filesets { get; set; }
    }

    public class LanguagesResultMetadata
    {
        public LanguagesResultMetadataPagination? Pagination { get; set; }
    }

    public class LanguagesResultMetadataPagination
    {
        public int? Total { get; set; }

        public int? Count { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }

        public LanguagesResultMetadataPaginationLinks? Links { get; set; }
    }

    public class LanguagesResultMetadataPaginationLinks
    {
        public string? Previous { get; set; }

        public string? Next { get; set; }
    }

    public class LanguageInfoResult
    {
        public LanguageInfo? Data { get; set; }
    }

    public class LanguageInfo
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Autonym { get; set; }

        [JsonProperty("glotto_id")]
        public string? GlottoId { get; set; }

        public string? Iso { get; set; }

        public string? Maps { get; set; }

        public string? Area { get; set; }

        public int? Population { get; set; }

        [JsonProperty("country_id")]
        public string? CountryId { get; set; }

        [JsonProperty("country_name")]
        public string? CountryName { get; set; }

        public object? AlternativeNames { get; set; }

        [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
        public Dictionary<string, string>? Classifications { get; set; }

        public LanguageInfoBible[]? Bibles { get; set; }

        public LanguageInfoResource[]? Resources { get; set; }
    }

    public class LanguageInfoBible
    {
        public string? Id { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        public BibleVersification? Versification { get; set; }

        [JsonProperty("numeral_system_id")]
        public string? NumeralSystemId { get; set; }

        public string? Scope { get; set; }

        public string? Script { get; set; }

        public string? Derived { get; set; }

        public string? Copyright { get; set; }

        public int? Reviewed { get; set; }

        public LanguageInfoBibleTranslation[]? Translations { get; set; }

        public LanguageInfoBibleFileset[]? Filesets { get; set; }
    }

    public class LanguageInfoBibleTranslation
    {
        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        [JsonProperty("bible_id")]
        public string? BibleId { get; set; }

        public int? Vernacular { get; set; }

        [JsonProperty("vernacular_trade")]
        public int? VernacularTrade { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }

    public class LanguageInfoBibleFileset
    {
        public string? Id { get; set; }

        [JsonProperty("asset_id")]
        public string? AssetId { get; set; }

        [JsonProperty("set_type_code")]
        public string? SetTypeCode { get; set; }

        [JsonProperty("set_size_code")]
        public string? SetSizeCode { get; set; }

        [JsonProperty("laravel_through_key")]
        public string? LaravelThroughKey { get; set; }

        public LanguageInfoBibleFilesetMetadata[]? Meta { get; set; }
    }

    public class LanguageInfoBibleFilesetMetadata
    {
        [JsonProperty("hash_id")]
        public string? HashId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Iso { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }
    }

    public class LanguageInfoResource
    {
        public int? Id { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        public string? Iso { get; set; }

        [JsonProperty("organization_id")]
        public int? OrganizationId { get; set; }

        [JsonProperty("source_id")]
        public string? SourceId { get; set; }

        public string? Cover { get; set; }

        [JsonProperty("cover_thumbnail")]
        public string? CoverThumbnail { get; set; }

        public string? Type { get; set; }

        public LanguageInfoResourceTranslation[]? Translations { get; set; }

        public LanguageInfoResourceLink[]? Links { get; set; }
    }

    public class LanguageInfoResourceTranslation
    {
        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }

    public class LanguageInfoResourceLink
    {
        public string? Title { get; set; }

        public string? Type { get; set; }

        public string? Url { get; set; }
    }

    public class LanguageSearchResult
    {
        public LanguageSearch[]? Data { get; set; }

        public LanguageSearchResultMetadata? Meta { get; set; }
    }

    public class LanguageSearch
    {
        public int? Id { get; set; }

        [JsonProperty("glotto_id")]
        public string? GlottoId { get; set; }

        public string? Iso { get; set; }

        public string? Name { get; set; }

        public string? Autonym { get; set; }

        public int? Bibles { get; set; }
    }

    public class LanguageSearchResultMetadata
    {
        public LanguageSearchResultMetadataPagination? Pagination { get; set; }
    }

    public class LanguageSearchResultMetadataPagination
    {
        public int? Total { get; set; }

        public int? Count { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
    }
}
