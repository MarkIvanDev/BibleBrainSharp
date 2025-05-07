using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models;

public class SearchResult
{
    [JsonPropertyName("audio_filesets")]
    public SearchAudioFileset[]? AudioFilesets { get; set; }

    public VersesResult? Verses { get; set; }
}

public class SearchAudioFileset
{
    public string? Id { get; set; }

    [JsonPropertyName("asset_id")]
    public string? AssetId { get; set; }

    [JsonPropertyName("set_type_code")]
    public MediaType? SetTypeCode { get; set; }

    [JsonPropertyName("set_size_code")]
    public FilesetSize? SetSizeCode { get; set; }

    [JsonPropertyName("laravel_through_key")]
    public string? LaravelThroughKey { get; set; }

    public SearchAudioFilesetMetadata[]? Meta { get; set; }
}

public class SearchAudioFilesetMetadata
{
    public string? HashId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Iso { get; set; }

    [JsonPropertyName("language_id")]
    public int? LanguageId { get; set; }
}
