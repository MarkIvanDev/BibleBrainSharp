// MIT License

// Copyright(c) 2021 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BibleBrainSharp
{
    public static class ApiExtensions
    {
        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequest request)
        {
            try
            {
                var response = await client.GetAsync(request.ToString()).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(json);
                }
                return default;
            }
            catch (Exception)
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

        public static void AddOptionalParameter(this NameValueCollection query, string key, string value)
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
