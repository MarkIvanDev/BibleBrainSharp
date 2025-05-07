using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<Country>> GetCountries(string? l10n = null, bool? include_languages = null, CancellationToken cancellationToken = default)
    {
        var countries = new List<Country>();
        var request = new HttpRequest(ApiEndpoints.Countries);
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

    private static HttpRequest GetCountriesPaginatedRequest(int page, string? l10n = null, bool? include_languages = null, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.Countries);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(l10n), l10n);
        request.Query.AddOptionalParameter(nameof(include_languages), include_languages);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<CountriesResult?> GetCountriesPaginated(int page, string? l10n = null, bool? include_languages = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetCountriesPaginatedRequest(page, l10n, include_languages, limit);
        var response = await httpClient.ExecuteAsync<CountriesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetCountriesPaginatedJson(int page, string? l10n = null, bool? include_languages = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetCountriesPaginatedRequest(page, l10n, include_languages, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<CountryInfoResult?> GetCountry(string countryId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCountry(countryId));
        var response = await httpClient.ExecuteAsync<CountryInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetCountryJson(string countryId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCountry(countryId));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<CountrySearch>> SearchCountries(string searchText, CancellationToken cancellationToken = default)
    {
        var countries = new List<CountrySearch>();
        var request = new HttpRequest(ApiEndpoints.GetCountrySearch(searchText));

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

    private static HttpRequest SearchCountriesPaginatedRequest(int page, string searchText, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.GetCountrySearch(searchText));
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<CountrySearchResult?> SearchCountriesPaginated(int page, string searchText, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = SearchCountriesPaginatedRequest(page, searchText, limit);
        var response = await httpClient.ExecuteAsync<CountrySearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
    public async Task<string?> SearchCountriesPaginatedJson(int page, string searchText, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = SearchCountriesPaginatedRequest(page, searchText, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
