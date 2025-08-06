using System;
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

            languages.AddRange(response.Data ?? Array.Empty<Language>());

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
        int page,
        string? country,
        string? language_code,
        string? language_name,
        bool? include_translations,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.Languages, options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(country), country);
        request.Query.AddOptionalParameter(nameof(language_code), language_code);
        request.Query.AddOptionalParameter(nameof(language_name), language_name);
        request.Query.AddOptionalParameter(nameof(include_translations), include_translations);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<LanguagesResult?> GetLanguagesPaginated(
        int page,
        string? country = null,
        string? language_code = null,
        string? language_name = null,
        bool? include_translations = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetLanguagesPaginatedRequest(page, country, language_code, language_name, include_translations, limit, options);
        var response = await httpClient.ExecuteAsync<LanguagesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetLanguagesPaginatedJson(
        int page,
        string? country = null,
        string? language_code = null,
        string? language_name = null,
        bool? include_translations = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetLanguagesPaginatedRequest(page, country, language_code, language_name, include_translations, limit, options);
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
        int page,
        string searchText,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.GetLanguageSearch(searchText), options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<LanguageSearchResult?> SearchLanguagesPaginated(
        int page,
        string searchText,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchLanguagesPaginatedRequest(page, searchText, limit, options);
        var response = await httpClient.ExecuteAsync<LanguageSearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchLanguagesPaginatedJson(
        int page,
        string searchText,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchLanguagesPaginatedRequest(page, searchText, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
