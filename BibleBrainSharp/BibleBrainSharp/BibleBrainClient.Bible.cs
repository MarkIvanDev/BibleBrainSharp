using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<IList<Bible>> GetBibles(
        string? language_code = null,
        string? asset_id = null,
        MediaType? media = null,
        MediaType? media_exclude = null,
        FilesetSize? size = null,
        FilesetSize? size_exclude = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var bibles = new List<Bible>();
        var request = new HttpRequest(ApiEndpoints.Bibles, options);
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

    private static HttpRequest GetBiblesPaginatedRequest(
        string? language_code,
        string? asset_id,
        MediaType? media,
        MediaType? media_exclude,
        FilesetSize? size,
        FilesetSize? size_exclude,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.Bibles, options);
        request.Query.AddOptionalParameter(nameof(language_code), language_code);
        request.Query.AddOptionalParameter(nameof(asset_id), asset_id);
        request.Query.AddOptionalParameter(nameof(media), media?.GetValue());
        request.Query.AddOptionalParameter(nameof(media_exclude), media_exclude?.GetValue());
        request.Query.AddOptionalParameter(nameof(size), size?.GetValue());
        request.Query.AddOptionalParameter(nameof(size_exclude), size_exclude?.GetValue());
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);

        return request;
    }

    public async Task<BiblesResult?> GetBiblesPaginated(
        string? language_code = null,
        string? asset_id = null,
        MediaType? media = null,
        MediaType? media_exclude = null,
        FilesetSize? size = null,
        FilesetSize? size_exclude = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetBiblesPaginatedRequest(language_code, asset_id, media, media_exclude, size, size_exclude, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<BiblesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetBiblesPaginatedJson(
        string? language_code = null,
        string? asset_id = null,
        MediaType? media = null,
        MediaType? media_exclude = null,
        FilesetSize? size = null,
        FilesetSize? size_exclude = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetBiblesPaginatedRequest(language_code, asset_id, media, media_exclude, size, size_exclude, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<BibleInfoResult?> GetBible(
        string bibleId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBible(bibleId), options);
        var response = await httpClient.ExecuteAsync<BibleInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetBibleJson(
        string bibleId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBible(bibleId), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<BooksResult?> GetBooks(
        string bibleId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBooks(bibleId), options);
        var response = await httpClient.ExecuteAsync<BooksResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetBooksJson(
        string bibleId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetBooks(bibleId), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<Copyright>?> GetCopyright(
        string bibleId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCopyright(bibleId), options);
        var response = await httpClient.ExecuteAsync<Copyright[]>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetCopyrightJson(
        string bibleId,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetCopyright(bibleId), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<VersesResult?> GetChapter(
        string fileSetId,
        string bookId,
        int chapter,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetChapter(fileSetId, bookId, chapter), options);
        var response = await httpClient.ExecuteAsync<VersesResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetChapterJson(
        string fileSetId,
        string bookId,
        int chapter,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetChapter(fileSetId, bookId, chapter), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IDictionary<string, DefaultBible>?> GetDefaultBibles(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.DefaultBibles, options);
        var response = await httpClient.ExecuteAsync<Dictionary<string, DefaultBible>>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetDefaultBiblesJson(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.DefaultBibles, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IDictionary<MediaType, string>?> GetMediaTypes(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.MediaTypes, options);
        var response = await httpClient.ExecuteAsync<Dictionary<MediaType, string>>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetMediaTypesJson(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.MediaTypes, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<VerseByLanguage>> GetVersesByLanguage(
        string languageCode,
        string bookId,
        int chapter,
        int? verse = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var verses = new List<VerseByLanguage>();
        var request = new HttpRequest(ApiEndpoints.GetVersesByLanguage(languageCode, bookId, chapter, verse), options);

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

    private static HttpRequest GetVersesByLanguagePaginatedRequest(
        string languageCode,
        string bookId,
        int chapter,
        int? verse,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.GetVersesByLanguage(languageCode, bookId, chapter, verse), options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<VerseByLanguageResult?> GetVersesByLanguagePaginated(
        string languageCode,
        string bookId,
        int chapter,
        int? verse = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetVersesByLanguagePaginatedRequest(languageCode, bookId, chapter, verse, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<VerseByLanguageResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetVersesByLanguagePaginatedJson(
        string languageCode,
        string bookId,
        int chapter,
        int? verse = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetVersesByLanguagePaginatedRequest(languageCode, bookId, chapter, verse, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<VerseByVersion>> GetVersesByVersion(
        string bibleId,
        string bookId,
        int chapter,
        int? verse = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var verses = new List<VerseByVersion>();
        var request = new HttpRequest(ApiEndpoints.GetVersesByVersion(bibleId, bookId, chapter, verse), options);

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

    private static HttpRequest GetVersesByVersionPaginatedRequest(
        string bibleId,
        string bookId,
        int chapter,
        int? verse,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.GetVersesByVersion(bibleId, bookId, chapter, verse), options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<VerseByVersionResult?> GetVersesByVersionPaginated(
        string bibleId,
        string bookId,
        int chapter,
        int? verse = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetVersesByVersionPaginatedRequest(bibleId, bookId, chapter, verse, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<VerseByVersionResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetVersesByVersionPaginatedJson(
        string bibleId,
        string bookId,
        int chapter,
        int? verse = null,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = GetVersesByVersionPaginatedRequest(bibleId, bookId, chapter, verse, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<BibleSearchByVersion>> SearchBiblesByVersion(
        string version,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var bibles = new List<BibleSearchByVersion>();
        var request = new HttpRequest(ApiEndpoints.BibleSearch, options);
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

    private static HttpRequest SearchBiblesByVersionPaginatedRequest(
        string version,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.BibleSearch, options);
        request.Query.AddRequiredParameter(nameof(version), version);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<BibleSearchByVersionResult?> SearchBiblesByVersionPaginated(
        string version,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesByVersionPaginatedRequest(version, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<BibleSearchByVersionResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchBiblesByVersionPaginatedJson(
        string version,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesByVersionPaginatedRequest(version, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<IList<BibleSearch>> SearchBibles(
        string searchText,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var bibles = new List<BibleSearch>();
        var request = new HttpRequest(ApiEndpoints.GetBibleSearch(searchText), options);

        int currentPage;
        int lastPage;
        do
        {
            var response = await httpClient.ExecuteAsync<BibleSearchResult>(request, cancellationToken).ConfigureAwait(false);
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

    private static HttpRequest SearchBiblesPaginatedRequest(
        string searchText,
        int page,
        int? limit,
        BibleBrainClientOptions? options)
    {
        var request = new HttpRequest(ApiEndpoints.GetBibleSearch(searchText), options);
        request.Query.AddRequiredParameter(nameof(page), page);
        request.Query.AddOptionalParameter(nameof(limit), limit);
        return request;
    }

    public async Task<BibleSearchResult?> SearchBiblesPaginated(
        string searchText,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesPaginatedRequest(searchText, page ?? 1, limit, options);
        var response = await httpClient.ExecuteAsync<BibleSearchResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> SearchBiblesPaginatedJson(
        string searchText,
        int? page = null,
        int? limit = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = SearchBiblesPaginatedRequest(searchText, page ?? 1, limit, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<VerseInfoResult?> GetVerseInfo(
        string filesetId,
        string bookId,
        int? chapter = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetVerseInfo(filesetId, bookId, chapter), options);
        var response = await httpClient.ExecuteAsync<VerseInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetVerseInfoJson(
        string filesetId,
        string bookId,
        int? chapter = null,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetVerseInfo(filesetId, bookId, chapter), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
