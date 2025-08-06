using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BibleBrainSharp;

internal static class ApiExtensions
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public static async Task<T?> ExecuteAsync<T>(this HttpClient client, HttpRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await client.SendAsync(request.ToRequestMessage(), cancellationToken).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var json =
#if NET5_0_OR_GREATER
                    await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                return JsonSerializer.Deserialize<T>(json, JsonSerializerOptions);
            }
            return default;
        }
        catch
        {
            if (request?.Options?.RethrowExceptions ?? false)
            {
                throw;
            }
            return default;
        }
    }

    public static async Task<string?> ExecuteJsonAsync(this HttpClient client, HttpRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await client.SendAsync(request.ToRequestMessage(), cancellationToken).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var json =
#if NET5_0_OR_GREATER
                    await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
                return json;
            }
            return default;
        }
        catch
        {
            if (request?.Options?.RethrowExceptions ?? false)
            {
                throw;
            }
            return default;
        }
    }

    public static void AddRequiredParameter(this NameValueCollection query, string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            query.Add(key, value);
        }
        else
        {
            throw new ArgumentNullException(nameof(value));
        }
    }

    public static void AddRequiredParameter<T>(this NameValueCollection query, string key, T value) where T : struct
    {
        query.Add(key, value.ToString());
    }

    public static void AddOptionalParameter(this NameValueCollection query, string key, string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            query.Add(key, value);
        }
    }

    public static void AddOptionalParameter<T>(this NameValueCollection query, string key, T? value) where T : struct
    {
        if (value.HasValue)
        {
            if (value.Value is bool b)
            {
                query.Add(key, b ? "true" : "false");
            }
            else
            {
                query.Add(key, value.Value.ToString());
            }
        }
    }

    public static string ToQueryString(this NameValueCollection query)
    {
        var queryString = from key in query.AllKeys
                          from value in query.GetValues(key) ?? []
                          select string.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value));
        return string.Join("&", queryString);
    }
}

internal class HttpRequest(string requestUri, BibleBrainClientOptions? options)
{
    public string RequestUri { get; } = requestUri;

    public NameValueCollection Query { get; } = [];

    public BibleBrainClientOptions? Options { get; } = options;

    public override string ToString()
    {
        return $"{RequestUri}?{Query.ToQueryString()}";
    }

    public HttpRequestMessage ToRequestMessage()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, ToString());
        if (Options is not null)
        {
            request.Headers.Add("key", Options.ApiKey);
        }
        return request;
    }
}
