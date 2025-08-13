using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<Language>> GetLanguages(
        string? country = null,
        string? language_code = null,
        string? language_name = null,
        bool? include_translations = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var languages = new List<Language>();
        var request = new HttpRequest(ApiEndpoints.Languages, options);
        request.Query.AddOptionalParameter(nameof(country), country);
        request.Query.AddOptionalParameter(nameof(language_code), language_code);
        request.Query.AddOptionalParameter(nameof(language_name), language_name);
        request.Query.AddOptionalParameter(nameof(include_translations), include_translations);

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<LanguagesResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            languages.AddRange(response.Data ?? []);

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

        return languages;
    }

    private static HttpRequest GetLanguagesPaginatedRequest(
        string? country,
        string? language_code,
        string? language_name,
        bool? include_translations,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.Languages, options);
        request.Query.AddOptionalParameter(nameof(country), country);
        request.Query.AddOptionalParameter(nameof(language_code), language_code);
        request.Query.AddOptionalParameter(nameof(language_name), language_name);
        request.Query.AddOptionalParameter(nameof(include_translations), include_translations);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<LanguagesResult?> GetLanguagesPaginated(
        string? country = null,
        string? language_code = null,
        string? language_name = null,
        bool? include_translations = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetLanguagesPaginatedRequest(country, language_code, language_name, include_translations, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<LanguagesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetLanguagesPaginatedJson(
        string? country = null,
        string? language_code = null,
        string? language_name = null,
        bool? include_translations = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetLanguagesPaginatedRequest(country, language_code, language_name, include_translations, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<LanguageInfoResult?> GetLanguage(
        int languageId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetLanguage(languageId), options);
        var response = await httpClient.ExecuteAsync<LanguageInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetLanguageJson(
        int languageId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetLanguage(languageId), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<LanguageSearch>> SearchLanguages(
        string searchText,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var languages = new List<LanguageSearch>();
        var request = new HttpRequest(ApiEndpoints.GetLanguageSearch(searchText), options);

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<LanguageSearchResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            languages.AddRange(response.Data ?? []);

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

        return languages;
    }

    private static HttpRequest SearchLanguagesPaginatedRequest(
        string searchText,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.GetLanguageSearch(searchText), options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<LanguageSearchResult?> SearchLanguagesPaginated(
        string searchText,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchLanguagesPaginatedRequest(searchText, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<LanguageSearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchLanguagesPaginatedJson(
        string searchText,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchLanguagesPaginatedRequest(searchText, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
