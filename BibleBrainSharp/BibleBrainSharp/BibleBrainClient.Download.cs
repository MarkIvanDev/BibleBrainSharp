using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp
{
    public partial class BibleBrainClient
    {
        public async Task<IList<DownloadableFileset>> GetDownloadableFilesets()
        {
            var filesets = new List<DownloadableFileset>();
            var request = new HttpRequest(ApiEndpoints.DownloadList);

            int currentPage;
            int totalPages;
            do
            {
                var response = await httpClient.ExecuteAsync<DownloadableFilesetResult>(request).ConfigureAwait(false);
                if (response is null) break;

                filesets.AddRange(response.Data ?? Array.Empty<DownloadableFileset>());

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

        public async Task<DownloadableFilesetResult?> GetDownloadableFilesetsPaginated(int page, int? limit = null)
        {
            var request = new HttpRequest(ApiEndpoints.DownloadList);
            request.Query.AddRequiredParameter(nameof(page), page);
            request.Query.AddOptionalParameter(nameof(limit), limit);
            var response = await httpClient.ExecuteAsync<DownloadableFilesetResult>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<DownloadContentResult?> GetDownloadContent(string filesetId, string bookId, int? chapter = null)
        {
            var request = new HttpRequest(ApiEndpoints.GetDownload(filesetId, bookId, chapter));
            var response = await httpClient.ExecuteAsync<DownloadContentResult>(request).ConfigureAwait(false);
            return response;
        }
    }
}
