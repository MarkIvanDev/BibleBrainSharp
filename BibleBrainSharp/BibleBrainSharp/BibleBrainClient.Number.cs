﻿using System.Threading;
using System.Threading.Tasks;
using BibleBrainSharp.Models;

namespace BibleBrainSharp;

public partial class BibleBrainClient
{
    public async Task<NumbersResult?> GetNumbers(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Numbers);
        var response = await httpClient.ExecuteAsync<NumbersResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetNumbersJson(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.Numbers);
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<NumberInfoResult?> GetNumber(string numeralSystem, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem));
        var response = await httpClient.ExecuteAsync<NumberInfoResult>(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

    public async Task<string?> GetNumberJson(string numeralSystem, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequest(ApiEndpoints.GetNumber(numeralSystem));
        var response = await httpClient.ExecuteJsonAsync(request, cancellationToken).ConfigureAwait(false);
        return response;
    }

}
