using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<Country>> GetCountries(
        string? l10n = null,
        bool? include_languages = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var countries = new List<Country>();
        var request = new HttpRequest(ApiEndpoints.Countries, options);
        request.Query.AddOptionalParameter(nameof(l10n), l10n);
        request.Query.AddOptionalParameter(nameof(include_languages), include_languages);

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<CountriesResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            countries.AddRange(response.Data ?? []);

            var cp = response.Meta?.Pagination?.CurrentPage;
            var tp = response.Meta?.Pagination?.TotalPages;
            if (cp.HasValue && tp.HasValue)
            {
                currentPage = cp.Value;
                totalPages = tp.Value;
                request.Query.Set("page", (currentPage + 1).ToString());
            }
            else
            {
                break;
            }
        } while (currentPage < totalPages);

        return countries;
    }

    private static HttpRequest GetCountriesPaginatedRequest(
        string? l10n,
        bool? include_languages,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.Countries, options);
        request.Query.AddOptionalParameter(nameof(l10n), l10n);
        request.Query.AddOptionalParameter(nameof(include_languages), include_languages);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<CountriesResult?> GetCountriesPaginated(
        string? l10n = null,
        bool? include_languages = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetCountriesPaginatedRequest(l10n, include_languages, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<CountriesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetCountriesPaginatedJson(
        string? l10n = null,
        bool? include_languages = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetCountriesPaginatedRequest(l10n, include_languages, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<CountryInfoResult?> GetCountry(
        string countryId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCountry(countryId), options);
        var response = await httpClient.ExecuteAsync<CountryInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetCountryJson(
        string countryId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCountry(countryId), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<CountrySearch>> SearchCountries(
        string searchText,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var countries = new List<CountrySearch>();
        var request = new HttpRequest(ApiEndpoints.GetCountrySearch(searchText), options);

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<CountrySearchResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            countries.AddRange(response.Data ?? []);

            var cp = response.Meta?.Pagination?.CurrentPage;
            var tp = response.Meta?.Pagination?.TotalPages;
            if (cp.HasValue && tp.HasValue)
            {
                currentPage = cp.Value;
                totalPages = tp.Value;
                request.Query.Set("page", (currentPage + 1).ToString());
            }
            else
            {
                break;
            }
        } while (currentPage < totalPages);

        return countries;
    }

    private static HttpRequest SearchCountriesPaginatedRequest(
        string searchText,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.GetCountrySearch(searchText), options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<CountrySearchResult?> SearchCountriesPaginated(
        string searchText,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchCountriesPaginatedRequest(searchText, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<CountrySearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
    public async Task<string?> SearchCountriesPaginatedJson(
        string searchText,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchCountriesPaginatedRequest(searchText, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
