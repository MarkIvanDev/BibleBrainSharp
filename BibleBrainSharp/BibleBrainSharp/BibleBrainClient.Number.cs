using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<NumbersResult?> GetNumbers(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Numbers, options);
        var response = await httpClient.ExecuteAsync<NumbersResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetNumbersJson(
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Numbers, options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<NumberInfoResult?> GetNumber(
        string numeralSystem,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem), options);
        var response = await httpClient.ExecuteAsync<NumberInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetNumberJson(
        string numeralSystem,
        BibleBrainClientOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem), options);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

}
