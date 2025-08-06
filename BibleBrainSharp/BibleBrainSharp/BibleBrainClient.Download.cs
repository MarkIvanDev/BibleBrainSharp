using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<DownloadableFileset>> GetDownloadableFilesets(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var filesets = new List<DownloadableFileset>();
        var request = new HttpRequest(ApiEndpoints.DownloadList, options);

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<DownloadableFilesetResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            filesets.AddRange(response.Data ?? []);

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

        return filesets;
    }

    private static HttpRequest GetDownloadableFilesetsPaginatedRequest(
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.DownloadList, options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<DownloadableFilesetResult?> GetDownloadableFilesetsPaginated(
        int page,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetDownloadableFilesetsPaginatedRequest(page, limit, options);
        var response = await httpClient.ExecuteAsync<DownloadableFilesetResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetDownloadableFilesetsPaginatedJson(
        int page,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetDownloadableFilesetsPaginatedRequest(page, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<DownloadContentResult?> GetDownloadContent(
        string filesetId,
        string bookId,
        int? chapter = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetDownload(filesetId, bookId, chapter), options);
        var response = await httpClient.ExecuteAsync<DownloadContentResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetDownloadContentJson(
        string filesetId,
        string bookId,
        int? chapter = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetDownload(filesetId, bookId, chapter), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
