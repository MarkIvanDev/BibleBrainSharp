using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<IList<Language>> GetLanguages(string country = default, string language_code = default, string language_name = default, bool? include_translations = default)
        {
            var languages = new List<Language>();
            var request = new HttpRequest(ApiEndpoints.Languages);
            request.Query.AddOptionalParameter(nameof(country), country);
            request.Query.AddOptionalParameter(nameof(language_code), language_code);
            request.Query.AddOptionalParameter(nameof(language_name), language_name);
            request.Query.AddOptionalParameter(nameof(include_translations), include_translations);

            LanguagesResult response;
            do
            {
                response = await httpClient.ExecuteAsync<LanguagesResult>(request);
                if (response is null) break;

                languages.AddRange(response.Data);
                request.Query.Set("page", (response.Meta.Pagination.CurrentPage + 1).ToString());
            } while (response.Meta.Pagination.CurrentPage < response.Meta.Pagination.TotalPages);

            return languages;
        }

        public async Task<LanguageInfoResult> GetLanguage(int languageId)
        {
            var request = new HttpRequest(ApiEndpoints.GetLanguage(languageId));
            var response = await httpClient.ExecuteAsync<LanguageInfoResult>(request);
            return response;
        }
    }
}
