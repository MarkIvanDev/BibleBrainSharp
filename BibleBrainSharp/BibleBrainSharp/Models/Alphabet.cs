using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models;

public class AlphabetsResult
{
    public Alphabet[]? Data { get; set; }
}

public class Alphabet
{
    public string? Name { get; set; }

    public string? Script { get; set; }

    public string? Family { get; set; }

    public string? Type { get; set; }

    public AlphabetDirection? Direction { get; set; }
}

public class AlphabetInfoResult
{
    public AlphabetInfo? Data { get; set; }
}

public class AlphabetInfo
{
    public string? Script { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("unicode_pdf")]
    public string? UnicodePdf { get; set; }

    public string? Family { get; set; }

    public string? Type { get; set; }

    [JsonPropertyName("white_space")]
    public string? Whitespace { get; set; }

    [JsonPropertyName("open_type_tag")]
    public string? OpenTypeTag { get; set; }

    [JsonPropertyName("complex_positioning")]
    public bool? ComplexPositioning { get; set; }

    [JsonPropertyName("requires_font")]
    public bool? RequiresFont { get; set; }

    public bool? Unicode { get; set; }

    public bool? Diacritics { get; set; }

    [JsonPropertyName("contextual_forms")]
    public bool? ContextualForms { get; set; }

    public bool? Reordering { get; set; }

    public bool? Case { get; set; }

    [JsonPropertyName("split_graphs")]
    public bool? SplitGraphs { get; set; }

    public AlphabetStatus? Status { get; set; }

    public AlphabetBaseline? Baseline { get; set; }

    public AlphabetLigature? Ligatures { get; set; }

    public AlphabetDirection? Direction { get; set; }

    [JsonPropertyName("direction_notes")]
    public string? DirectionNotes { get; set; }

    public string? Sample { get; set; }

    [JsonPropertyName("sample_img")]
    public string? SampleImage { get; set; }

    public string? Description { get; set; }

    public AlphabetFont[]? Fonts { get; set; }

    public AlphabetLanguage[]? Languages { get; set; }

    public AlphabetBible[]? Bibles { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AlphabetStatus
{
    Current,
    Historical,
    Fictional,
    Unclear,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AlphabetBaseline
{
    Hanging,
    Centered,
    Bottom,
    Vertical,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AlphabetLigature
{
    None,
    Required,
    Optional,
}

public class AlphabetFont
{
    public int? Id { get; set; }

    public string? FontName { get; set; }

    public string? FontFileName { get; set; }

    public int? FontWeight { get; set; }

    public string? Copyright { get; set; }

    public string? Url { get; set; }

    public string? Notes { get; set; }

    public string? Italic { get; set; }
}

public class AlphabetLanguage
{
    public int? Id { get; set; }

    [JsonPropertyName("glotto_id")]
    public string? GlottoId { get; set; }

    public string? Iso { get; set; }

    public string? Iso2B { get; set; }

    public string? Iso2T { get; set; }

    public string? Iso1 { get; set; }

    public string? Name { get; set; }

    public string? Maps { get; set; }

    public string? Development { get; set; }

    public string? Use { get; set; }

    public string? Location { get; set; }

    public string? Area { get; set; }

    public int? Population { get; set; }

    [JsonPropertyName("population_notes")]
    public string? PopulationNotes { get; set; }

    public string? Notes { get; set; }

    public string? Typology { get; set; }

    public string? Writing { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    [JsonPropertyName("status_id")]
    public string? StatusId { get; set; }

    [JsonPropertyName("country_id")]
    public string? CountryId { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    public AlphabetLanguagePivot? Pivot { get; set; }
}

public class AlphabetLanguagePivot
{
    [JsonPropertyName("script_id")]
    public string? ScriptId { get; set; }

    [JsonPropertyName("language_id")]
    public int? LanguageId { get; set; }
}

public class AlphabetBible
{
    public string? Id { get; set; }

    [JsonPropertyName("language_id")]
    public int? LanguageId { get; set; }

    public BibleVersification? Versification { get; set; }

    [JsonPropertyName("numeral_system_id")]
    public string? NumeralSystemId { get; set; }

    public string? Date { get; set; }

    public string? Scope { get; set; }

    public string? Script { get; set; }

    public string? Derived { get; set; }

    public string? Copyright { get; set; }

    public int? Reviewed { get; set; }

    public string? Notes { get; set; }

    [JsonPropertyName("current_translation")]
    public AlphabetBibleTranslation? CurrentTranslation { get; set; }
}

public class AlphabetBibleTranslation
{
    [JsonPropertyName("language_id")]
    public int? LanguageId { get; set; }

    [JsonPropertyName("bible_id")]
    public string? BibleId { get; set; }

    public int? Vernacular { get; set; }

    [JsonPropertyName("vernacular_trade")]
    public int? VernacularTrade { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Background { get; set; }
}
