using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class DownloadableFilesetResult
    {
        public DownloadableFileset[]? Data { get; set; }

        public DownloadableFilesetResultMetadata? Meta { get; set; }
    }

    public class DownloadableFileset
    {
        public string? Type { get; set; }

        public string? Language { get; set; }

        public string? Licensor { get; set; }

        [JsonProperty("fileset_id")]
        public string? FilesetId { get; set; }
    }

    public class DownloadableFilesetResultMetadata
    {
        public DownloadableFilesetResultMetadataPagination? Pagination { get; set; }
    }

    public class DownloadableFilesetResultMetadataPagination
    {
        public int? Total { get; set; }

        public int? Count { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }

        public DownloadableFilesetResultMetadataPaginationLinks? Links { get; set; }
    }

    public class DownloadableFilesetResultMetadataPaginationLinks
    {
        public string? Previous { get; set; }

        public string? Next { get; set; }
    }

    public class DownloadContentResult
    {
        public DownloadContent[]? Data { get; set; }

        public DownloadContentResultMetadata? Meta { get; set; }
    }

    public class DownloadContent
    {
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

        public int? Duration { get; set; }

        public string? Thumbnail { get; set; }

        [JsonProperty("filesize_in_bytes")]
        public int? FileSizeInBytes { get; set; }

        [JsonProperty("youtube_url")]
        public string? YoutubeUrl { get; set; }
    }

    public class DownloadContentResultMetadata
    {
        public string? Thumbnail { get; set; }

        [JsonProperty("zip_file")]
        public string? ZipFile { get; set; }

        public DownloadContentResultMetadataPagination? Pagination { get; set; }
    }

    public class DownloadContentResultMetadataPagination
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
