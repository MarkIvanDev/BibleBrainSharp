using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<SearchResult>> Search(string query, string fileset_id, string[]? books = default, CancellationToken cancellationToken = default)
    {
        var searches = new List<SearchResult>();
        var request = new HttpRequest(ApiEndpoints.Search);
        request.Query.AddRequiredParameter(nameof(query), query);
        request.Query.AddRequiredParameter(nameof(fileset_id), fileset_id);
        request.Query.AddRequiredParameter("limit", 1000);
        request.Query.AddRequiredParameter("page", 1);
        request.Query.AddOptionalParameter(nameof(books), string.Join(",", books ?? Array.Empty<string>()));

        bool isMetaNull;
        int currentPage = 0;
        int totalPages = 0;
        do
        {
            var response = await httpClient.ExecuteAsync<SearchResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            searches.Add(response);

            var meta = response.Verses?.Meta;
            if (meta != null)
            {
                isMetaNull = false;
                var cp = response.Verses?.Meta?.Pagination?.CurrentPage;
                var tp = response.Verses?.Meta?.Pagination?.TotalPages;
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

            }
            else
            {
                isMetaNull = true;
                request.Query.Set("page", "2");
            }
        } while (isMetaNull || currentPage < totalPages);

        return searches;
    }

    private static HttpRequest SearchPaginatedRequest(int page, string query, string fileset_id, string[]? books = null, int limit = 1000)
    {
        var request = new HttpRequest(ApiEndpoints.Search);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddRequiredParameter(nameof(query), query);
        request.Query.AddRequiredParameter(nameof(fileset_id), fileset_id);
        request.Query.AddRequiredParameter(nameof(limit), limit);
        request.Query.AddOptionalParameter(nameof(books), string.Join(",", books ?? Array.Empty<string>()));
        return request;
    }

    public async Task<SearchResult?> SearchPaginated(int page, string query, string fileset_id, string[]? books = null, int limit = 1000, CancellationToken cancellationToken = default)
    {
        var request = SearchPaginatedRequest(page, query, fileset_id, books, limit);
        var response = await httpClient.ExecuteAsync<SearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchPaginatedJson(int page, string query, string fileset_id, string[]? books = null, int limit = 1000, CancellationToken cancellationToken = default)
    {
        var request = SearchPaginatedRequest(page, query, fileset_id, books, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
