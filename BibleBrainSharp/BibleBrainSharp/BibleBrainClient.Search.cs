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
        public async Task<IList<Search>> Search(string query, string fileset_id, string[] books = default)
        {
            var searches = new List<Search>();
            var request = new HttpRequest(ApiEndpoints.Search);
            request.Query.AddRequiredParameter(nameof(query), query);
            request.Query.AddRequiredParameter(nameof(fileset_id), fileset_id);
            request.Query.AddRequiredParameter("limit", 1000);
            request.Query.AddRequiredParameter("page", 1);
            request.Query.AddOptionalParameter(nameof(books), string.Join(",", books ?? Array.Empty<string>()));

            Search response;
            do
            {
                response = await httpClient.ExecuteAsync<Search>(request).ConfigureAwait(false);
                if (response is null) break;

                searches.Add(response);
                
                request.Query.Set("page", response.Verses.Meta is null ?
                    "2" :
                    (response.Verses.Meta.Pagination.CurrentPage + 1).ToString());
            } while (response.Verses.Meta is null || response.Verses.Meta.Pagination.CurrentPage < response.Verses.Meta.Pagination.TotalPages);

            return searches;
        }
    }
}
