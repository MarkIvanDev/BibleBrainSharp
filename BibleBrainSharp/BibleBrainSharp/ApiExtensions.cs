﻿using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BibleBrainSharp
{
    public static class ApiExtensions
    {
        public static async Task<T?> ExecuteAsync<T>(this HttpClient client, HttpRequest request)
        {
            try
            {
                var response = await client.GetAsync(request.ToString()).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
                }
                return default;
            }
            catch (Exception ex)
            {
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
                              from value in query.GetValues(key)
                              select string.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value));
            return string.Join("&", queryString);
        }
    }

    public class HttpRequest
    {
        public HttpRequest(string requestUri)
        {
            RequestUri = requestUri;
            Query = new NameValueCollection();
        }

        public string RequestUri { get; }

        public NameValueCollection Query { get; }

        public override string ToString()
        {
            return $"{RequestUri}?{Query.ToQueryString()}";
        }
    }
}
