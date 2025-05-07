using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{

    public async Task<IList<FilesetId>?> GetFilesetsWithTimestamps(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Timestamps);
        var response = await httpClient.ExecuteAsync<FilesetId[]>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetFilesetsWithTimestampsJson(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Timestamps);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<TimestampsResult?> GetTimestamps(string fileSetId, string bookId, int chapter, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetTimestamps(fileSetId, bookId, chapter));
        var response = await httpClient.ExecuteAsync<TimestampsResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetTimestampsJson(string fileSetId, string bookId, int chapter, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetTimestamps(fileSetId, bookId, chapter));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

}
