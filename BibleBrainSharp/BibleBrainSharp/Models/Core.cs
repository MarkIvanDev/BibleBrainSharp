using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models;

[JsonConverter(typeof(DefaultEnumConverter<AlphabetDirection>))]
public enum AlphabetDirection
{
    [JsonStringEnumMemberName("")]
    Unknown,

    [JsonStringEnumMemberName("ltr")]
    LTR,

    [JsonStringEnumMemberName("rtl")]
    RTL,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
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

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MediaType
{
    [JsonStringEnumMemberName("text_plain")]
    TextPlain,

    [JsonStringEnumMemberName("text_format")]
    TextFormat,

    [JsonStringEnumMemberName("text_usx")]
    TextUsx,

    [JsonStringEnumMemberName("text_html")]
    TextHtml,

    [JsonStringEnumMemberName("text_json")]
    TextJson,

    [JsonStringEnumMemberName("audio")]
    Audio,

    [JsonStringEnumMemberName("audio_drama")]
    AudioDrama,

    [JsonStringEnumMemberName("audio_stream")]
    AudioStream,

    [JsonStringEnumMemberName("audio_drama_stream")]
    AudioDramaStream,

    [JsonStringEnumMemberName("video_stream")]
    VideoStream
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FilesetSize
{
    C,
    OT,
    NT,
    OTP,
    NTP,
    OTNTP,
    NTOTP,
    NTPOTP,
    S,
    P,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BookTestament
{
    OT,
    NT,
    AP,
}

public static class EnumExtensions
{
    public static string GetValue<T>(this T e) where T : struct, Enum
    {
        return JsonSerializer.Serialize(e).Trim('\"');
    }
}

public class Verse
{
    [JsonPropertyName("fileset_id")]
    public string? FilesetId { get; set; }

    [JsonPropertyName("book_id")]
    public string? BookId { get; set; }

    [JsonPropertyName("book_name")]
    public string? BookName { get; set; }

    [JsonPropertyName("book_name_alt")]
    public string? BookNameAlt { get; set; }

    public int? Chapter { get; set; }

    [JsonPropertyName("chapter_alt")]
    public string? ChapterAlt { get; set; }

    [JsonPropertyName("chapter_start")]
    public int? ChapterStart { get; set; }

    [JsonPropertyName("chapter_end")]
    public int? ChapterEnd { get; set; }

    [JsonPropertyName("verse_start")]
    public int? VerseStart { get; set; }

    [JsonPropertyName("verse_start_alt")]
    public string? VerseStartAlt { get; set; }

    [JsonPropertyName("verse_end")]
    public int? VerseEnd { get; set; }

    [JsonPropertyName("verse_end_alt")]
    public string? VerseEndAlt { get; set; }

    [JsonPropertyName("verse_text")]
    public string? VerseText { get; set; }

    public string? Path { get; set; }

    public string? Thumbnail { get; set; }

    public int? Duration { get; set; }

    public string? Bitrate { get; set; }

    public string? Container { get; set; }

    [JsonPropertyName("multiple_mp3")]
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

    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("current_page")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("total_pages")]
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
    [JsonPropertyName("dbp-prod")]
    public Fileset[]? Prod { get; set; }

    [JsonPropertyName("dbp-vid")]
    public Fileset[]? Vid { get; set; }
}

public class Fileset
{
    public string? Id { get; set; }

    public MediaType? Type { get; set; }

    public FilesetSize? Size { get; set; }

    [JsonPropertyName("stock_no")]
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

    [JsonPropertyName("url_facebook")]
    public string? Facebook { get; set; }

    [JsonPropertyName("url_website")]
    public string? Website { get; set; }

    [JsonPropertyName("url_donate")]
    public string? Donate { get; set; }

    [JsonPropertyName("url_twitter")]
    public string? Twitter { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    [JsonPropertyName("email_director")]
    public string? EmailDirector { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    [JsonPropertyName("laravel_through_key")]
    public string? LaravelThroughKey { get; set; }

    public OrganizationPivot? Pivot { get; set; }

    [JsonPropertyName("logo_icon")]
    public OrganizationLogoIcon? Logo { get; set; }

    public OrganizationLogoIcon[]? Logos { get; set; }

    public OrganizationTranslation[]? Translations { get; set; }
}

public class OrganizationPivot
{
    [JsonPropertyName("bible_id")]
    public string? BibleId { get; set; }

    [JsonPropertyName("organization_id")]
    public int? OrganizationId { get; set; }

    [JsonPropertyName("relationship_type")]
    public string? RelationshipType { get; set; }
}

public class OrganizationLogoIcon
{
    [JsonPropertyName("language_id")]
    public int? LanguageId { get; set; }

    [JsonPropertyName("language_iso")]
    public string? LanguageIso { get; set; }

    public string? Url { get; set; }

    public int? Icon { get; set; }
}

public class OrganizationTranslation
{
    [JsonPropertyName("language_id")]
    public int? LanguageId { get; set; }

    public int? Vernacular { get; set; }

    public int? Alt { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("description_short")]
    public string? DescriptionShort { get; set; }
}
