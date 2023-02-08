using System.Runtime.Serialization;
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
        RTL,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BibleVersification
    {
        Protestant,
        Luther,
        Synodal,
        German,
        KJVA,
        Vulgate,
        LXX,
        Orthodox,
        NRSVA,
        Catholic,
        Finnish,
        Messianic,
    }

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

        [EnumMember(Value = "text_json")]
        TextJson,

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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BookTestament
    {
        OT,
        NT,
        AP,
    }

    public static class EnumExtensions
    {
        public static string GetValue(this MediaType mediaType)
        {
            return JsonConvert.SerializeObject(mediaType).Trim('\"');
        }
    }

    public class Verse
    {
        [JsonProperty("fileset_id")]
        public string? FilesetId { get; set; }

        [JsonProperty("book_id")]
        public string? BookId { get; set; }

        [JsonProperty("book_name")]
        public string? BookName { get; set; }

        [JsonProperty("book_name_alt")]
        public string? BookNameAlt { get; set; }

        public int? Chapter { get; set; }

        [JsonProperty("chapter_alt")]
        public string? ChapterAlt { get; set; }

        [JsonProperty("chapter_start")]
        public int? ChapterStart { get; set; }

        [JsonProperty("chapter_end")]
        public int? ChapterEnd { get; set; }

        [JsonProperty("verse_start")]
        public int? VerseStart { get; set; }

        [JsonProperty("verse_start_alt")]
        public string? VerseStartAlt { get; set; }

        [JsonProperty("verse_end")]
        public int? VerseEnd { get; set; }

        [JsonProperty("verse_end_alt")]
        public string? VerseEndAlt { get; set; }

        [JsonProperty("verse_text")]
        public string? VerseText { get; set; }

        public string? Path { get; set; }

        public string? Thumbnail { get; set; }

        public int? Duration { get; set; }

        public string? Bitrate { get; set; }

        public string? Container { get; set; }

        [JsonProperty("multiple_mp3")]
        public bool? MultipleMp3 { get; set; }
    }

    public class VersesResult
    {
        public Verse[]? Data { get; set; }

        public VersesResultMetadata? Meta { get; set; }
    }

    public class VersesResultMetadata
    {
        public VersesResultMetadataPagination? Pagination { get; set; }
    }

    public class VersesResultMetadataPagination
    {
        public int? Total { get; set; }

        public int? Count { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }

        [JsonConverter(typeof(VersesResultMetadataPaginationLinksConverter))]
        public VersesResultMetadataPaginationLinks? Links { get; set; }
    }

    public class VersesResultMetadataPaginationLinks
    {
        public string? Previous { get; set; }

        public string? Next { get; set; }
    }

    public class Filesets
    {
        [JsonProperty("dbp-prod")]
        public Fileset[]? Prod { get; set; }

        [JsonProperty("dbp-vid")]
        public Fileset[]? Vid { get; set; }
    }

    public class Fileset
    {
        public string? Id { get; set; }

        public string? Type { get; set; }

        public string? Size { get; set; }

        [JsonProperty("stock_no")]
        public string? StockNo { get; set; }

        public string? Volume { get; set; }
    }

    public class Organization
    {
        public int? Id { get; set; }

        public string? Slug { get; set; }

        public string? Abbreviation { get; set; }

        public string? PrimaryColor { get; set; }

        public string? SecondaryColor { get; set; }

        public int? Inactive { get; set; }

        [JsonProperty("url_facebook")]
        public string? Facebook { get; set; }

        [JsonProperty("url_website")]
        public string? Website { get; set; }

        [JsonProperty("url_donate")]
        public string? Donate { get; set; }

        [JsonProperty("url_twitter")]
        public string? Twitter { get; set; }

        public string? Address { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public int? Zip { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        [JsonProperty("email_director")]
        public string? EmailDirector { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [JsonProperty("laravel_through_key")]
        public string? LaravelThroughKey { get; set; }

        public OrganizationPivot? Pivot { get; set; }

        [JsonProperty("logo_icon")]
        public OrganizationLogoIcon? Logo { get; set; }

        public OrganizationLogoIcon[]? Logos { get; set; }

        public OrganizationTranslation[]? Translations { get; set; }
    }

    public class OrganizationPivot
    {
        [JsonProperty("bible_id")]
        public string? BibleId { get; set; }

        [JsonProperty("organization_id")]
        public int? OrganizationId { get; set; }

        [JsonProperty("relationship_type")]
        public string? RelationshipType { get; set; }
    }

    public class OrganizationLogoIcon
    {
        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        [JsonProperty("language_iso")]
        public string? LanguageIso { get; set; }

        public string? Url { get; set; }

        public int? Icon { get; set; }
    }

    public class OrganizationTranslation
    {
        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        public int? Vernacular { get; set; }

        public int? Alt { get; set; }

        public string? Name { get; set; }

        [JsonProperty("description_short")]
        public string? DescriptionShort { get; set; }
    }
}
