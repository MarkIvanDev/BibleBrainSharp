using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<IList<Language>> GetLanguages(string? country = null, string? language_code = null, string? language_name = null, bool? include_translations = null)
        {
            var languages = new List<Language>();
            var request = new HttpRequest(ApiEndpoints.Languages);
            request.Query.AddOptionalParameter(nameof(country), country);
            request.Query.AddOptionalParameter(nameof(language_code), language_code);
            request.Query.AddOptionalParameter(nameof(language_name), language_name);
            request.Query.AddOptionalParameter(nameof(include_translations), include_translations);

            int currentPage;
            int totalPages;
            do
            {
                var response = await httpClient.ExecuteAsync<LanguagesResult>(request).ConfigureAwait(false);
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

        public async Task<LanguagesResult?> GetLanguagesPaginated(int page, string? country = null, string? language_code = null, string? language_name = null, bool? include_translations = null, int? limit = null)
        {
            var request = new HttpRequest(ApiEndpoints.Languages);
            request.Query.AddRequiredParameter(nameof(page), page);
            request.Query.AddOptionalParameter(nameof(country), country);
            request.Query.AddOptionalParameter(nameof(language_code), language_code);
            request.Query.AddOptionalParameter(nameof(language_name), language_name);
            request.Query.AddOptionalParameter(nameof(include_translations), include_translations);
            request.Query.AddOptionalParameter(nameof(limit), limit);
            var response = await httpClient.ExecuteAsync<LanguagesResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<LanguageInfoResult?> GetLanguage(int languageId)
        {
            var request = new HttpRequest(ApiEndpoints.GetLanguage(languageId));
            var response = await httpClient.ExecuteAsync<LanguageInfoResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<IList<LanguageSearch>> SearchLanguages(string searchText)
        {
            var languages = new List<LanguageSearch>();
            var request = new HttpRequest(ApiEndpoints.GetLanguageSearch(searchText));

            int currentPage;
            int totalPages;
            do
            {
                var response = await httpClient.ExecuteAsync<LanguageSearchResult>(request).ConfigureAwait(false);
                if (response is null) break;

                languages.AddRange(response.Data ?? Array.Empty<LanguageSearch>());

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

        public async Task<LanguageSearchResult?> SearchLanguagesPaginated(int page, string searchText, int? limit = null)
        {
            var request = new HttpRequest(ApiEndpoints.GetLanguageSearch(searchText));
            request.Query.AddRequiredParameter(nameof(page), page);
            request.Query.AddOptionalParameter(nameof(limit), limit);
            var response = await httpClient.ExecuteAsync<LanguageSearchResult>(request).ConfigureAwait(false);
            return response;
        }
    }
}
