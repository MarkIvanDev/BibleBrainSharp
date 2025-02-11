using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models
{
    public class BiblesResult
    {
        public Bible[]? Data { get; set; }

        public BiblesResultMetadata? Meta { get; set; }
    }

    public class Bible
    {
        public string? Abbr { get; set; }

        public string? Name { get; set; }

        public string? VName { get; set; }

        public string? Language { get; set; }

        public string? Autonym { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }

        public string? Iso { get; set; }

        public string? Date { get; set; }

        [JsonConverter(typeof(FilesetsConverter))]
        public Filesets? Filesets { get; set; }
    }

    public class BiblesResultMetadata
    {
        public BiblesResultMetadataPagination? Pagination { get; set; }
    }

    public class BiblesResultMetadataPagination
    {
        public int? Total { get; set; }

        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }

        [JsonPropertyName("current_page")]
        public int? CurrentPage { get; set; }

        [JsonPropertyName("last_page")]
        public int? LastPage { get; set; }

        [JsonPropertyName("next_page_url")]
        public string? Next { get; set; }

        [JsonPropertyName("prev_page_url")]
        public object? Previous { get; set; }

        public int? From { get; set; }

        public int? To { get; set; }
    }

    public class BibleInfoResult
    {
        public BibleInfo? Data { get; set; }
    }

    public class BibleInfo
    {
        public string? Abbr { get; set; }

        public BibleInfoAlphabet? Alphabet { get; set; }

        public string? Mark { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? VName { get; set; }

        public string? VDescription { get; set; }

        [JsonConverter(typeof(BibleInfoPublishersConverter))]
        public Organization[]? Publishers { get; set; }

        public Organization[]? Providers { get; set; }

        public BibleInfoEquivalent[]? Equivalents { get; set; }

        public string? Language { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }

        public string? Iso { get; set; }

        public string? Date { get; set; }

        public string? Country { get; set; }

        public BibleInfoBook[]? Books { get; set; }

        public BibleInfoLink[]? Links { get; set; }

        [JsonConverter(typeof(FilesetsConverter))]
        public Filesets? Filesets { get; set; }

        public BibleInfoFont? Fonts { get; set; }
    }

    public class BibleInfoAlphabet
    {
        public string? Script { get; set; }

        public string? Name { get; set; }

        public AlphabetDirection? Direction { get; set; }

        public bool? Unicode { get; set; }

        [JsonPropertyName("requires_font")]
        public bool? RequiresFont { get; set; }
    }

    public class BibleInfoEquivalent
    {
        public string? BibleId { get; set; }

        public string? EquivalentId { get; set; }

        public int? OrganizationId { get; set; }

        public string? Type { get; set; }

        public string? Site { get; set; }

        public string? Suffix { get; set; }
    }

    public class BibleInfoBook
    {
        [JsonPropertyName("book_id")]
        public string? Id { get; set; }

        public string? Name { get; set; }

        [JsonPropertyName("name_short")]
        public string? ShortName { get; set; }

        public int[]? Chapters { get; set; }

        public BookTestament? Testament { get; set; }
    }

    public class BibleInfoLink
    {
        [JsonPropertyName("bible_id")]
        public string? BibleId { get; set; }

        public string? Type { get; set; }

        public string? Url { get; set; }

        public string? Title { get; set; }

        public string? Provider { get; set; }

        [JsonPropertyName("organization_id")]
        public int? OrganizationId { get; set; }
    }

    public class BibleInfoFont
    {
        public string? Name { get; set; }

        public string? Data { get; set; }

        public string? Type { get; set; }
    }

    public class BooksResult
    {
        public Book[]? Data { get; set; }
    }

    public class Book
    {
        [JsonPropertyName("book_id")]
        public string? BookId { get; set; }

        [JsonPropertyName("book_id_usfx")]
        public string? UsfxId { get; set; }

        [JsonPropertyName("book_id_osis")]
        public string? OsisId { get; set; }

        public string? Name { get; set; }

        [JsonPropertyName("name_short")]
        public string? ShortName { get; set; }

        public BookTestament? Testament { get; set; }

        [JsonPropertyName("testament_order")]
        public int? TestamentOrder { get; set; }

        [JsonPropertyName("book_order")]
        public string? BookOrder { get; set; }

        [JsonPropertyName("book_group")]
        public string? BookGroup { get; set; }

        public int[]? Chapters { get; set; }

        [JsonPropertyName("content_types")]
        public string[]? ContentTypes { get; set; }
    }

    public class Copyright
    {
        public string? Id { get; set; }

        public MediaType? Type { get; set; }

        public FilesetSize? Size { get; set; }

        [JsonPropertyName("copyright")]
        public CopyrightInfo? CopyrightInfo { get; set; }
    }

    public class CopyrightInfo
    {
        [JsonPropertyName("copyright_date")]
        public string? Date { get; set; }

        public string? Copyright { get; set; }

        [JsonPropertyName("copyright_description")]
        public string? Description { get; set; }

        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string? UpdatedAt { get; set; }

        [JsonPropertyName("open_access")]
        public int? OpenAccess { get; set; }

        public Organization[]? Organizations { get; set; }
    }

    public class DefaultBible
    {
        public string? Audio { get; set; }

        public string? Video { get; set; }
    }

    public class VerseByLanguageResult
    {
        public VerseByLanguage[]? Data { get; set; }

        public VerseByLanguageResultMetadata? Meta { get; set; }
    }

    public class VerseByLanguage
    {
        [JsonPropertyName("verse_start")]
        public int? VerseStart { get; set; }

        [JsonPropertyName("verse_end")]
        public int? VerseEnd { get; set; }

        public int? Chapter { get; set; }

        [JsonPropertyName("book_id")]
        public string? BookId { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }

        [JsonPropertyName("bible_id")]
        public string? BibleId { get; set; }

        [JsonPropertyName("verse_text")]
        public string? VerseText { get; set; }

        [JsonPropertyName("fileset_id")]
        public string? FilesetId { get; set; }

        [JsonPropertyName("fileset_set_type_code")]
        public MediaType? FilesetSetTypeCode { get; set; }

        [JsonPropertyName("fileset_set_size_code")]
        public FilesetSize? FilesetSetSizeCode { get; set; }

        public VerseByLanguageBibleFileset[]? BibleFilesets { get; set; }
    }

    public class VerseByLanguageBibleFileset
    {
        public string? Id { get; set; }

        [JsonPropertyName("asset_id")]
        public string? AssetId { get; set; }

        [JsonPropertyName("set_type_code")]
        public MediaType? SetTypeCode { get; set; }

        [JsonPropertyName("set_size_code")]
        public FilesetSize? SetSizeCode { get; set; }
    }

    public class VerseByLanguageResultMetadata
    {
        public VerseByLanguageResultMetadataPagination? Pagination { get; set; }
    }

    public class VerseByLanguageResultMetadataPagination
    {
        public int? Total { get; set; }

        public int? Count { get; set; }

        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }

        [JsonPropertyName("current_page")]
        public int? CurrentPage { get; set; }

        [JsonPropertyName("total_pages")]
        public int? TotalPages { get; set; }

        public VerseByLanguageResultMetadataPaginationLinks? Links { get; set; }
    }

    public class VerseByLanguageResultMetadataPaginationLinks
    {
        public string? Previous { get; set; }

        public string? Next { get; set; }
    }

    public class VerseByVersionResult
    {
        public VerseByVersion[]? Data { get; set; }

        public VerseByVersionResultMetadata? Meta { get; set; }
    }

    public class VerseByVersion
    {
        [JsonPropertyName("verse_start")]
        public int? VerseStart { get; set; }

        [JsonPropertyName("verse_end")]
        public int? VerseEnd { get; set; }

        public int? Chapter { get; set; }

        [JsonPropertyName("book_id")]
        public string? BookId { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }

        [JsonPropertyName("bible_id")]
        public string? BibleId { get; set; }

        [JsonPropertyName("verse_text")]
        public string? VerseText { get; set; }

        [JsonPropertyName("fileset_id")]
        public string? FilesetId { get; set; }

        [JsonPropertyName("fileset_set_type_code")]
        public MediaType? FilesetSetTypeCode { get; set; }

        [JsonPropertyName("fileset_set_size_code")]
        public FilesetSize? FilesetSetSizeCode { get; set; }

        public VerseByVersionBibleFileset[]? BibleFilesets { get; set; }
    }

    public class VerseByVersionBibleFileset
    {
        public string? Id { get; set; }

        [JsonPropertyName("asset_id")]
        public string? AssetId { get; set; }

        [JsonPropertyName("set_type_code")]
        public MediaType? SetTypeCode { get; set; }

        [JsonPropertyName("set_size_code")]
        public FilesetSize? SetSizeCode { get; set; }
    }

    public class VerseByVersionResultMetadata
    {
        public VerseByVersionResultMetadataPagination? Pagination { get; set; }
    }

    public class VerseByVersionResultMetadataPagination
    {
        public int? Total { get; set; }

        public int? Count { get; set; }

        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }

        [JsonPropertyName("current_page")]
        public int? CurrentPage { get; set; }

        [JsonPropertyName("total_pages")]
        public int? TotalPages { get; set; }

        public VerseByVersionResultMetadataPaginationLinks? Links { get; set; }
    }

    public class VerseByVersionResultMetadataPaginationLinks
    {
        public string? Previous { get; set; }

        public string? Next { get; set; }
    }

    public class BibleSearchByVersionResult
    {
        public BibleSearchByVersion[]? Data { get; set; }

        public BibleSearchByVersionResultMetadata? Meta { get; set; }
    }

    public class BibleSearchByVersion
    {
        public string? Abbr { get; set; }

        public string? Name { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }
    }

    public class BibleSearchByVersionResultMetadata
    {
        public BibleSearchByVersionResultMetadataPagination? Pagination { get; set; }
    }

    public class BibleSearchByVersionResultMetadataPagination
    {
        public int? Total { get; set; }

        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }

        [JsonPropertyName("current_page")]
        public int? CurrentPage { get; set; }

        [JsonPropertyName("last_page")]
        public int? LastPage { get; set; }

        [JsonPropertyName("next_page_url")]
        public string? NextPageUrl { get; set; }

        [JsonPropertyName("prev_page_url")]
        public string? PrevPageUrl { get; set; }

        public int? From { get; set; }

        public int? To { get; set; }
    }

    public class BibleSearchResult
    {
        public BibleSearch[]? Data { get; set; }

        public BibleSearchResultMetadata? Meta { get; set; }
    }

    public class BibleSearch
    {
        public string? Abbr { get; set; }

        public string? Name { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }
    }

    public class BibleSearchResultMetadata
    {
        public BibleSearchResultMetadataPagination? Pagination { get; set; }
    }

    public class BibleSearchResultMetadataPagination
    {
        public int? Total { get; set; }

        [JsonPropertyName("per_page")]
        public int? PerPage { get; set; }

        [JsonPropertyName("current_page")]
        public int? CurrentPage { get; set; }

        [JsonPropertyName("last_page")]
        public int? LastPage { get; set; }

        [JsonPropertyName("next_page_url")]
        public string? NextPageUrl { get; set; }

        [JsonPropertyName("prev_page_url")]
        public string? PrevPageUrl { get; set; }

        public int? From { get; set; }

        public int? To { get; set; }
    }

    public class VerseInfoResult
    {
        public VerseInfo[]? Data { get; set; }
    }

    public class VerseInfo
    {
        [JsonPropertyName("book_id")]
        public string? BookId { get; set; }

        [JsonPropertyName("book_name")]
        public string? BookName { get; set; }

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

        public int? Duration { get; set; }

        public string? Thumbnail { get; set; }

        [JsonPropertyName("filesize_in_bytes")]
        public int? FileSizeInBytes { get; set; }

        [JsonPropertyName("youtube_url")]
        public string? YoutubeUrl { get; set; }
    }
}
