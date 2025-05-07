using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models;

public class TimestampsResult
{
    public Timestamp[]? Data { get; set; }
}

public class Timestamp
{
    public string? Book { get; set; }

    public string? Chapter { get; set; }

    [JsonPropertyName("verse_start")]
    public string? VerseStart { get; set; }

    [JsonPropertyName("timestamp")]
    public double? TimestampInfo { get; set; }
}

public class FilesetId
{
    [JsonPropertyName("fileset_id")]
    public string? Id { get; set; }
}
