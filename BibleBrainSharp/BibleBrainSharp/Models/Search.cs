using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class SearchResult
    {
        [JsonProperty("audio_filesets")]
        public SearchAudioFileset[]? AudioFilesets { get; set; }

        public VersesResult? Verses { get; set; }
    }

    public class SearchAudioFileset
    {
        public string? Id { get; set; }

        [JsonProperty("asset_id")]
        public string? AssetId { get; set; }

        [JsonProperty("set_type_code")]
        public MediaType? SetTypeCode { get; set; }

        [JsonProperty("set_size_code")]
        public string? SetSizeCode { get; set; }

        [JsonProperty("laravel_through_key")]
        public string? LaravelThroughKey { get; set; }

        public SearchAudioFilesetMetadata[]? Meta { get; set; }
    }

    public class SearchAudioFilesetMetadata
    {
        public string? HashId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Iso { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }
    }
}
