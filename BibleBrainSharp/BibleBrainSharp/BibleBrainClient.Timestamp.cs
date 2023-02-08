using System.Collections.Generic;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {

        public async Task<IList<FilesetId>?> GetFilesetsWithTimestamps()
        {
            var request = new HttpRequest(ApiEndpoints.Timestamps);
            var response = await httpClient.ExecuteAsync<FilesetId[]>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<TimestampsResult?> GetTimestamps(string fileSetId, string bookId, int chapter)
        {
            var request = new HttpRequest(ApiEndpoints.GetTimestamps(fileSetId, bookId, chapter));
            var response = await httpClient.ExecuteAsync<TimestampsResult>(request).ConfigureAwait(false);
            return response;
        }

    }
}
