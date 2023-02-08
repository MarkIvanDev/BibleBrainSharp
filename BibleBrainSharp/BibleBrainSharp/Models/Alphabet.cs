using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BibleBrainSharp.Models
{
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

        [JsonProperty("unicode_pdf")]
        public string? UnicodePdf { get; set; }

        public string? Family { get; set; }

        public string? Type { get; set; }

        [JsonProperty("white_space")]
        public string? Whitespace { get; set; }

        [JsonProperty("open_type_tag")]
        public string? OpenTypeTag { get; set; }

        [JsonProperty("complex_positioning")]
        public bool? ComplexPositioning { get; set; }

        [JsonProperty("requires_font")]
        public bool? RequiresFont { get; set; }

        public bool? Unicode { get; set; }

        public bool? Diacritics { get; set; }

        [JsonProperty("contextual_forms")]
        public bool? ContextualForms { get; set; }

        public bool? Reordering { get; set; }

        public bool? Case { get; set; }

        [JsonProperty("split_graphs")]
        public bool? SplitGraphs { get; set; }

        public AlphabetStatus? Status { get; set; }

        public AlphabetBaseline? Baseline { get; set; }

        public AlphabetLigature? Ligatures { get; set; }

        public AlphabetDirection? Direction { get; set; }

        [JsonProperty("direction_notes")]
        public string? DirectionNotes { get; set; }

        public string? Sample { get; set; }

        [JsonProperty("sample_img")]
        public string? SampleImage { get; set; }

        public string? Description { get; set; }

        public AlphabetFont[]? Fonts { get; set; }

        public AlphabetLanguage[]? Languages { get; set; }

        public AlphabetBible[]? Bibles { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlphabetStatus
    {
        Current,
        Historical,
        Fictional,
        Unclear,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlphabetBaseline
    {
        Hanging,
        Centered,
        Bottom,
        Vertical,
    }

    [JsonConverter(typeof(StringEnumConverter))]
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

        [JsonProperty("glotto_id")]
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

        [JsonProperty("population_notes")]
        public string? PopulationNotes { get; set; }

        public string? Notes { get; set; }

        public string? Typology { get; set; }

        public string? Writing { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [JsonProperty("status_id")]
        public string? StatusId { get; set; }

        [JsonProperty("country_id")]
        public string? CountryId { get; set; }

        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string? UpdatedAt { get; set; }

        public AlphabetLanguagePivot? Pivot { get; set; }
    }

    public class AlphabetLanguagePivot
    {
        [JsonProperty("script_id")]
        public string? ScriptId { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }
    }

    public class AlphabetBible
    {
        public string? Id { get; set; }

        [JsonProperty("language_id")]
        public int? LanguageId { get; set; }

        public BibleVersification? Versification { get; set; }

        [JsonProperty("numeral_system_id")]
        public string? NumeralSystemId { get; set; }

        public string? Date { get; set; }

        public string? Scope { get; set; }

        public string? Script { get; set; }

        public string? Derived { get; set; }

        public string? Copyright { get; set; }

        public int? Reviewed { get; set; }

        public string? Notes { get; set; }

        [JsonProperty("current_translation")]
        public AlphabetBibleTranslation? CurrentTranslation { get; set; }
    }

    public class AlphabetBibleTranslation
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

        public string? Background { get; set; }
    }
}
