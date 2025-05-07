using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BibleBrainSharp.Models;

public class CountriesResult
{
    public Country[]? Data { get; set; }

    public CountriesResultMetadata? Meta { get; set; }
}

public class Country
{
    public string? Name { get; set; }

    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    public CountryCodes? Codes { get; set; }
}

public class CountryCodes
{
    public string? Fips { get; set; }

    [JsonPropertyName("iso_a3")]
    public string? IsoA3 { get; set; }

    [JsonPropertyName("iso_a2")]
    public string? IsoA2 { get; set; }
}

public class CountriesResultMetadata
{
    public CountriesResultMetadataPagination? Pagination { get; set; }
}

public class CountriesResultMetadataPagination
{
    public int? Total { get; set; }

    public int? Count { get; set; }

    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("current_page")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("total_pages")]
    public int? TotalPages { get; set; }

    public CountriesResultMetadataPaginationLinks? Links { get; set; }
}

public class CountriesResultMetadataPaginationLinks
{
    public string? Previous { get; set; }

    public string? Next { get; set; }
}

public class CountryInfoResult
{
    public CountryInfo? Data { get; set; }
}

public class CountryInfo
{
    public string? Name { get; set; }

    public string? Introduction { get; set; }

    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, CountryInfoMap>))]
    public Dictionary<string, CountryInfoMap>? Maps { get; set; }

    public int? Wfb { get; set; }

    public int? Ethnologue { get; set; }

    public CountryInfoLanguage[]? Languages { get; set; }

    public CountryCodes? Codes { get; set; }
}

public class CountryInfoMap
{
    [JsonPropertyName("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }

    [JsonPropertyName("map_url")]
    public string? MapUrl { get; set; }
}

public class CountryInfoLanguage
{
    public string? Name { get; set; }

    public string? Iso { get; set; }

    [JsonConverter(typeof(DictionaryOrEmptyArrayConverter<string, string>))]
    public Dictionary<string, string>? Bibles { get; set; }
}

public class CountrySearchResult
{
    public CountrySearch[]? Data { get; set; }

    public CountrySearchResultMetadata? Meta { get; set; }
}

public class CountrySearch
{
    public string? Name { get; set; }

    public string? ContinentCode { get; set; }

    public CountrySearchCodes? Codes { get; set; }
}

public class CountrySearchCodes
{
    public string? Fips { get; set; }

    [JsonPropertyName("iso_a3")]
    public string? IsoA3 { get; set; }

    [JsonPropertyName("iso_a2")]
    public string? IsoA2 { get; set; }
}

public class CountrySearchResultMetadata
{
    public CountrySearchResultMetadataPagination? Pagination { get; set; }
}

public class CountrySearchResultMetadataPagination
{
    public int? Total { get; set; }

    public int? Count { get; set; }

    [JsonPropertyName("per_page")]
    public int? PerPage { get; set; }

    [JsonPropertyName("current_page")]
    public int? CurrentPage { get; set; }

    [JsonPropertyName("total_pages")]
    public int? TotalPages { get; set; }
}
