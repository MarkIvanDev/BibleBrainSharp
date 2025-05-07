using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<AlphabetsResult?> GetAlphabets(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Alphabets);
        var response = await httpClient.ExecuteAsync<AlphabetsResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetAlphabetsJson(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Alphabets);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<AlphabetInfoResult?> GetAlphabet(string alphabetId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetAlphabet(alphabetId));
        var response = await httpClient.ExecuteAsync<AlphabetInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetAlphabetJson(string alphabetId, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetAlphabet(alphabetId));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }
}
