// MIT License

// Copyright(c) 2021 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
                response = await httpClient.ExecuteAsync<LanguagesResult>(request).ConfigureAwait(false);
                if (response is null) break;

                languages.AddRange(response.Data);
                request.Query.Set("page", (response.Meta.Pagination.CurrentPage + 1).ToString());
            } while (response.Meta.Pagination.CurrentPage < response.Meta.Pagination.TotalPages);

            return languages;
        }

        public async Task<LanguageInfoResult> GetLanguage(int languageId)
        {
            var request = new HttpRequest(ApiEndpoints.GetLanguage(languageId));
            var response = await httpClient.ExecuteAsync<LanguageInfoResult>(request).ConfigureAwait(false);
            return response;
        }
    }
}
