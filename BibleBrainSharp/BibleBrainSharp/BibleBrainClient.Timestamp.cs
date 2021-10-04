using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {

        public async Task<IList<FileSetId>> GetFileSetsWithTimestamps()
        {
            var request = new HttpRequest(ApiEndpoints.Timestamps);
            var response = await httpClient.ExecuteAsync<FileSetId[]>(request);
            return response;
        }

        public async Task<TimestampsResult> GetTimestamps(string fileSetId, string bookId, int chapter)
        {
            var request = new HttpRequest(ApiEndpoints.GetTimestamps(fileSetId, bookId, chapter));
            var response = await httpClient.ExecuteAsync<TimestampsResult>(request);
            return response;
        }

    }
}
