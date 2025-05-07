using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<Bible>> GetBibles(string? language_code = null, string? asset_id = null, MediaType? media = null, MediaType? media_exclude = null, FilesetSize? size = null, FilesetSize? size_exclude = null, CancellationToken cancellationToken = default)
    {
        var bibles = new List<Bible>();
        var request = new HttpRequest(ApiEndpoints.Bibles);
        request.Query.AddOptionalParameter(nameof(language_code), language_code);
        request.Query.AddOptionalParameter(nameof(asset_id), asset_id);
        request.Query.AddOptionalParameter(nameof(media), media?.GetValue());
        request.Query.AddOptionalParameter(nameof(media_exclude), media_exclude?.GetValue());
        request.Query.AddOptionalParameter(nameof(size), size?.GetValue());
        request.Query.AddOptionalParameter(nameof(size_exclude), size_exclude?.GetValue());

        int currentPage;
        int lastPage;
        do
        {
            var response = await httpClient.ExecuteAsync<BiblesResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            bibles.AddRange(response.Data ?? []);

            var cp = response.Meta?.Pagination?.CurrentPage;
            var lp = response.Meta?.Pagination?.LastPage;
            if (cp.HasValue && lp.HasValue)
            {
                currentPage = cp.Value;
                lastPage = lp.Value;
                request.Query.Set("page", (currentPage + 1).ToString());
            }
            else
            {
                break;
            }
        } while (currentPage < lastPage);

        return bibles;
    }

    private static HttpRequest GetBiblesPaginatedRequest(int page, string? language_code = null, string? asset_id = null, MediaType? media = null, MediaType? media_exclude = null, FilesetSize? size = null, FilesetSize? size_exclude = null, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.Bibles);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        request.Query.AddOptionalParameter(nameof(language_code), language_code);
        request.Query.AddOptionalParameter(nameof(asset_id), asset_id);
        request.Query.AddOptionalParameter(nameof(media), media?.GetValue());
        request.Query.AddOptionalParameter(nameof(media_exclude), media_exclude?.GetValue());
        request.Query.AddOptionalParameter(nameof(size), size?.GetValue());
        request.Query.AddOptionalParameter(nameof(size_exclude), size_exclude?.GetValue());

        return request;
    }

    public async Task<BiblesResult?> GetBiblesPaginated(int page, string? language_code = null, string? asset_id = null, MediaType? media = null, MediaType? media_exclude = null, FilesetSize? size = null, FilesetSize? size_exclude = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetBiblesPaginatedRequest(page, language_code, asset_id, media, media_exclude, size, size_exclude, limit);
        var response = await httpClient.ExecuteAsync<BiblesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetBiblesPaginatedJson(int page, string? language_code = null, string? asset_id = null, MediaType? media = null, MediaType? media_exclude = null, FilesetSize? size = null, FilesetSize? size_exclude = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetBiblesPaginatedRequest(page, language_code, asset_id, media, media_exclude, size, size_exclude, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<BibleInfoResult?> GetBible(string bibleId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBible(bibleId));
        var response = await httpClient.ExecuteAsync<BibleInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetBibleJson(string bibleId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBible(bibleId));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<BooksResult?> GetBooks(string bibleId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBooks(bibleId));
        var response = await httpClient.ExecuteAsync<BooksResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetBooksJson(string bibleId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBooks(bibleId));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<Copyright>?> GetCopyright(string bibleId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCopyright(bibleId));
        var response = await httpClient.ExecuteAsync<Copyright[]>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetCopyrightJson(string bibleId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCopyright(bibleId));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<VersesResult?> GetChapter(string fileSetId, string bookId, int chapter, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetChapter(fileSetId, bookId, chapter));
        var response = await httpClient.ExecuteAsync<VersesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetChapterJson(string fileSetId, string bookId, int chapter, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetChapter(fileSetId, bookId, chapter));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IDictionary<string, DefaultBible>?> GetDefaultBibles(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.DefaultBibles);
        var response = await httpClient.ExecuteAsync<Dictionary<string, DefaultBible>>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetDefaultBiblesJson(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.DefaultBibles);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IDictionary<MediaType, string>?> GetMediaTypes(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.MediaTypes);
        var response = await httpClient.ExecuteAsync<Dictionary<MediaType, string>>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetMediaTypesJson(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.MediaTypes);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<VerseByLanguage>> GetVersesByLanguage(string languageCode, string bookId, int chapter, int? verse = null, CancellationToken cancellationToken = default)
    {
        var verses = new List<VerseByLanguage>();
        var request = new HttpRequest(ApiEndpoints.GetVersesByLanguage(languageCode, bookId, chapter, verse));

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<VerseByLanguageResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            verses.AddRange(response.Data ?? []);

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

        return verses;
    }

    private static HttpRequest GetVersesByLanguagePaginatedRequest(int page, string languageCode, string bookId, int chapter, int? verse = null, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.GetVersesByLanguage(languageCode, bookId, chapter, verse));
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<VerseByLanguageResult?> GetVersesByLanguagePaginated(int page, string languageCode, string bookId, int chapter, int? verse = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetVersesByLanguagePaginatedRequest(page, languageCode, bookId, chapter, verse, limit);
        var response = await httpClient.ExecuteAsync<VerseByLanguageResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetVersesByLanguagePaginatedJson(int page, string languageCode, string bookId, int chapter, int? verse = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetVersesByLanguagePaginatedRequest(page, languageCode, bookId, chapter, verse, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<VerseByVersion>> GetVersesByVersion(string bibleId, string bookId, int chapter, int? verse = null, CancellationToken cancellationToken = default)
    {
        var verses = new List<VerseByVersion>();
        var request = new HttpRequest(ApiEndpoints.GetVersesByVersion(bibleId, bookId, chapter, verse));

        int currentPage;
        int totalPages;
        do
        {
            var response = await httpClient.ExecuteAsync<VerseByVersionResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            verses.AddRange(response.Data ?? []);

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

        return verses;
    }

    private static HttpRequest GetVersesByVersionPaginatedRequest(int page, string bibleId, string bookId, int chapter, int? verse = null, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.GetVersesByVersion(bibleId, bookId, chapter, verse));
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<VerseByVersionResult?> GetVersesByVersionPaginated(int page, string bibleId, string bookId, int chapter, int? verse = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetVersesByVersionPaginatedRequest(page, bibleId, bookId, chapter, verse, limit);
        var response = await httpClient.ExecuteAsync<VerseByVersionResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetVersesByVersionPaginatedJson(int page, string bibleId, string bookId, int chapter, int? verse = null, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = GetVersesByVersionPaginatedRequest(page, bibleId, bookId, chapter, verse, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<BibleSearchByVersion>> SearchBiblesByVersion(string version, CancellationToken cancellationToken = default)
    {
        var bibles = new List<BibleSearchByVersion>();
        var request = new HttpRequest(ApiEndpoints.BibleSearch);
        request.Query.AddRequiredParameter(nameof(version), version);

        int currentPage;
        int lastPage;
        do
        {
            var response = await httpClient.ExecuteAsync<BibleSearchByVersionResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            bibles.AddRange(response.Data ?? []);

            var cp = response.Meta?.Pagination?.CurrentPage;
            var lp = response.Meta?.Pagination?.LastPage;
            if (cp.HasValue && lp.HasValue)
            {
                currentPage = cp.Value;
                lastPage = lp.Value;
                request.Query.Set("page", (currentPage + 1).ToString());
            }
            else
            {
                break;
            }
        } while (currentPage < lastPage);

        return bibles;
    }

    private static HttpRequest SearchBiblesByVersionPaginatedRequest(int page, string version, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.BibleSearch);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddRequiredParameter(nameof(version), version);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<BibleSearchByVersionResult?> SearchBiblesByVersionPaginated(int page, string version, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesByVersionPaginatedRequest(page, version, limit);
        var response = await httpClient.ExecuteAsync<BibleSearchByVersionResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchBiblesByVersionPaginatedJson(int page, string version, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesByVersionPaginatedRequest(page, version, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<BibleSearch>> SearchBibles(string searchText, CancellationToken cancellationToken = default)
    {
        var bibles = new List<BibleSearch>();
        var request = new HttpRequest(ApiEndpoints.GetBibleSearch(searchText));

        int currentPage;
        int lastPage;
        do
        {
            var response = await httpClient.ExecuteAsync<BibleSearchResult>(request, cancellationToken).ConfigureAwait(false);
            if (response is null) break;

            bibles.AddRange(response.Data);

            var cp = response.Meta?.Pagination?.CurrentPage;
            var lp = response.Meta?.Pagination?.LastPage;
            if (cp.HasValue && lp.HasValue)
            {
                currentPage = cp.Value;
                lastPage = lp.Value;
                request.Query.Set("page", (currentPage + 1).ToString());
            }
            else
            {
                break;
            }
        } while (currentPage < lastPage);

        return bibles;
    }

    private static HttpRequest SearchBiblesPaginatedRequest(int page, string searchText, int? limit = null)
    {
        var request = new HttpRequest(ApiEndpoints.GetBibleSearch(searchText));
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<BibleSearchResult?> SearchBiblesPaginated(int page, string searchText, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesPaginatedRequest(page, searchText, limit);
        var response = await httpClient.ExecuteAsync<BibleSearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchBiblesPaginatedJson(int page, string searchText, int? limit = null, CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesPaginatedRequest(page, searchText, limit);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<VerseInfoResult?> GetVerseInfo(string filesetId, string bookId, int? chapter = null, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetVerseInfo(filesetId, bookId, chapter));
        var response = await httpClient.ExecuteAsync<VerseInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetVerseInfoJson(string filesetId, string bookId, int? chapter = null, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetVerseInfo(filesetId, bookId, chapter));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
