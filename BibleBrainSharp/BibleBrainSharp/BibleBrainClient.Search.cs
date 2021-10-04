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
                response = await httpClient.ExecuteAsync<Search>(request);
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
