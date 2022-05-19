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
using System.Text;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<IList<Bible>> GetBibles(string language_code = null, string asset_id = null, MediaType? media = null, MediaType? media_exclude = null, string size = null, string size_exclude = null)
        {
            var bibles = new List<Bible>();
            var request = new HttpRequest(ApiEndpoints.Bibles);
            request.Query.AddOptionalParameter(nameof(language_code), language_code);
            request.Query.AddOptionalParameter(nameof(asset_id), asset_id);
            request.Query.AddOptionalParameter(nameof(media), media);
            request.Query.AddOptionalParameter(nameof(media_exclude), media_exclude);
            request.Query.AddOptionalParameter(nameof(size), size);
            request.Query.AddOptionalParameter(nameof(size_exclude), size_exclude);

            BiblesResult response;
            do
            {
                response = await httpClient.ExecuteAsync<BiblesResult>(request).ConfigureAwait(false);
                if (response is null) break;

                bibles.AddRange(response.Data);
                request.Query.Set("page", (response.Meta.Pagination.CurrentPage + 1).ToString());
            } while (response.Meta.Pagination.CurrentPage < response.Meta.Pagination.LastPage);

            return bibles;
        }

        public async Task<BibleInfoResult> GetBible(string bibleId)
        {
            var request = new HttpRequest(ApiEndpoints.GetBible(bibleId));
            var response = await httpClient.ExecuteAsync<BibleInfoResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<BooksResult> GetBooks(string bibleId)
        {
            var request = new HttpRequest(ApiEndpoints.GetBooks(bibleId));
            var response = await httpClient.ExecuteAsync<BooksResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<IList<Copyright>> GetCopyright(string bibleId)
        {
            var request = new HttpRequest(ApiEndpoints.GetCopyright(bibleId));
            var response = await httpClient.ExecuteAsync<Copyright[]>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<VersesResult> GetChapter(string fileSetId, string bookId, int chapter)
        {
            var request = new HttpRequest(ApiEndpoints.GetChapter(fileSetId, bookId, chapter));
            var response = await httpClient.ExecuteAsync<VersesResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<IDictionary<string, DefaultBible>> GetDefaultBibles()
        {
            var request = new HttpRequest(ApiEndpoints.DefaultBibles);
            var response = await httpClient.ExecuteAsync<Dictionary<string, DefaultBible>>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<IDictionary<MediaType, string>> GetMediaTypes()
        {
            var request = new HttpRequest(ApiEndpoints.MediaTypes);
            var response = await httpClient.ExecuteAsync<Dictionary<MediaType, string>>(request).ConfigureAwait(false);
            return response;
        }
    }
}
