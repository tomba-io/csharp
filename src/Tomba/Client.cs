using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Tomba
{
    /// <summary>
    /// The Tomba API client. Use this class to configure authentication and make API calls.
    /// </summary>
    /// <remarks>
    /// See <see href="https://docs.tomba.io/api">Tomba API Documentation</see>
    /// </remarks>
    public class Client
    {
        private readonly HttpClient http;

        private readonly Dictionary<string, string> headers;

        private readonly Dictionary<string, string> config;

        private string endPoint;

        private bool selfSigned;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class with default settings.
        /// </summary>
        public Client() :
            this("https://api.tomba.io/v1", false, new HttpClient())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class with custom settings.
        /// </summary>
        /// <param name="endPoint">The API endpoint URL</param>
        /// <param name="selfSigned">Whether to allow self-signed SSL certificates</param>
        /// <param name="http">The HttpClient instance to use</param>
        public Client(string endPoint, bool selfSigned, HttpClient http)
        {
            this.endPoint = endPoint;
            this.selfSigned = selfSigned;
            this.headers =
                new Dictionary<string, string>()
                {
                    { "content-type", "application/json" },
                    { "x-sdk-version", "tomba:dotnet:v1.0.1" }
                };
            this.config = new Dictionary<string, string>();
            this.http = http;
            this.http.Timeout = TimeSpan.FromSeconds(120);
        }

        /// <summary>
        /// Sets whether to allow self-signed SSL certificates.
        /// </summary>
        /// <param name="selfSigned">True to allow self-signed certificates</param>
        /// <returns>The client instance for method chaining</returns>
        public Client SetSelfSigned(bool selfSigned)
        {
            this.selfSigned = selfSigned;
            return this;
        }

        /// <summary>
        /// Sets the API endpoint URL.
        /// </summary>
        /// <param name="endPoint">The API endpoint URL</param>
        /// <returns>The client instance for method chaining</returns>
        public Client SetEndPoint(string endPoint)
        {
            this.endPoint = endPoint;
            return this;
        }

        /// <summary>
        /// Gets the current API endpoint URL.
        /// </summary>
        /// <returns>The API endpoint URL</returns>
        public string GetEndPoint()
        {
            return endPoint;
        }

        /// <summary>
        /// Gets the current client configuration.
        /// </summary>
        /// <returns>Dictionary of configuration key-value pairs</returns>
        public Dictionary<string, string> GetConfig()
        {
            return config;
        }

        /// <summary>
        /// Sets the API key for authentication.
        /// </summary>
        /// <param name="value">Your Tomba API key</param>
        /// <returns>The client instance for method chaining</returns>
        public Client SetKey(string value)
        {
            config.Add("key", value);
            AddHeader("X-Tomba-Key", value);
            return this;
        }

        /// <summary>
        /// Sets the API secret for authentication.
        /// </summary>
        /// <param name="value">Your Tomba API secret</param>
        /// <returns>The client instance for method chaining</returns>
        public Client SetSecret(string value)
        {
            config.Add("secret", value);
            AddHeader("X-Tomba-Secret", value);
            return this;
        }

        /// <summary>
        /// Adds a custom header to all requests.
        /// </summary>
        /// <param name="key">The header name</param>
        /// <param name="value">The header value</param>
        /// <returns>The client instance for method chaining</returns>
        public Client AddHeader(String key, String value)
        {
            headers.Add(key, value);
            return this;
        }

        /// <summary>
        /// Makes an HTTP request to the Tomba API.
        /// </summary>
        /// <param name="method">The HTTP method (GET, POST, PUT, DELETE)</param>
        /// <param name="path">The API path</param>
        /// <param name="headers">Additional headers for this request</param>
        /// <param name="parameters">Request parameters</param>
        /// <returns>The HTTP response message</returns>
        /// <exception cref="TombaException">Thrown when the API returns an error</exception>
        public async Task<HttpResponseMessage>
        Call(
            string method,
            string path,
            Dictionary<string, string> headers,
            Dictionary<string, object> parameters
        )
        {
            if (selfSigned)
            {
                ServicePointManager.ServerCertificateValidationCallback += (
                    sender,
                    certificate,
                    chain,
                    sslPolicyErrors
                ) => true;
            }

            bool methodGet =
                "GET"
                    .Equals(method,
                    StringComparison.InvariantCultureIgnoreCase);

            string queryString =
                methodGet ? "?" + parameters.ToQueryString() : string.Empty;

            HttpRequestMessage request =
                new HttpRequestMessage(new HttpMethod(method),
                    endPoint + path + queryString);

            if (!methodGet)
            {
                string body = parameters.ToJson();

                request.Content =
                    new StringContent(body, Encoding.UTF8, "application/json");
            }

            foreach (var header in this.headers)
            {
                if (
                    header
                        .Key
                        .Equals("content-type",
                        StringComparison.InvariantCultureIgnoreCase)
                )
                {
                    http
                        .DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue(header.Value));
                }
                else
                {
                    if (http.DefaultRequestHeaders.Contains(header.Key))
                    {
                        http.DefaultRequestHeaders.Remove(header.Key);
                    }
                    http.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            foreach (var header in headers)
            {
                if (
                    header
                        .Key
                        .Equals("content-type",
                        StringComparison.InvariantCultureIgnoreCase)
                )
                {
                    request
                        .Headers
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue(header.Value));
                }
                else
                {
                    if (request.Headers.Contains(header.Key))
                    {
                        request.Headers.Remove(header.Key);
                    }
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            try
            {
                var httpResponseMessage = await http.SendAsync(request);
                var code = (int)httpResponseMessage.StatusCode;
                var response =
                    await httpResponseMessage.Content.ReadAsStringAsync();

                if (code >= 400)
                {
                    var message = response.ToString();
                    var isJson =
                        httpResponseMessage
                            .Content
                            .Headers
                            .GetValues("Content-Type")
                            .FirstOrDefault()
                            .Contains("application/json");

                    if (isJson)
                    {
                        message =
                            (JObject.Parse(message))["errors"]["message"].ToString();
                    }

                    throw new TombaException(message,
                        code,
                        response.ToString());
                }

                return httpResponseMessage;
            }
            catch (System.Exception e)
            {
                throw new TombaException(e.Message, e);
            }
        }

        /// <summary>
        /// Parses rate limit headers from an HTTP response message.
        /// </summary>
        /// <param name="response">The HTTP response message</param>
        /// <returns>A RateLimit object with parsed header values</returns>
        public static RateLimit ParseRateLimit(HttpResponseMessage response)
        {
            return new RateLimit
            {
                SecondRateLimit = GetIntHeader(response, "x-second-rate-limit"),
                MinuteRateLimit = GetIntHeader(response, "x-minute-rate-limit"),
                DailyRateLimit = GetIntHeader(response, "x-daily-rate-limit"),
                MinuteRequestLeft = GetIntHeader(response, "x-minute-request-left"),
                DailyRequestLeft = GetIntHeader(response, "x-daily-request-left"),
                MinuteResetSeconds = GetIntHeader(response, "x-minute-reset-seconds"),
                DailyResetSeconds = GetIntHeader(response, "x-daily-reset-seconds"),
                RetryAfter = GetIntHeader(response, "Retry-After"),
                RateLimitPolicy = GetStringHeader(response, "RateLimit-Policy"),
                RateLimitValue = GetStringHeader(response, "RateLimit"),
            };
        }

        private static int? GetIntHeader(HttpResponseMessage response, string name)
        {
            if (response.Headers.TryGetValues(name, out var values))
            {
                var value = values.FirstOrDefault();
                if (int.TryParse(value, out var result))
                {
                    return result;
                }
            }
            return null;
        }

        private static string GetStringHeader(HttpResponseMessage response, string name)
        {
            if (response.Headers.TryGetValues(name, out var values))
            {
                return values.FirstOrDefault();
            }
            return null;
        }
    }

    /// <summary>
    /// Represents rate limit information extracted from API response headers.
    /// </summary>
    public class RateLimit
    {
        /// <summary>Per-second rate limit.</summary>
        public int? SecondRateLimit { get; set; }

        /// <summary>Per-minute rate limit.</summary>
        public int? MinuteRateLimit { get; set; }

        /// <summary>Per-day rate limit.</summary>
        public int? DailyRateLimit { get; set; }

        /// <summary>Remaining requests in the current minute window.</summary>
        public int? MinuteRequestLeft { get; set; }

        /// <summary>Remaining requests in the current daily window.</summary>
        public int? DailyRequestLeft { get; set; }

        /// <summary>Seconds until the per-minute rate limit resets.</summary>
        public int? MinuteResetSeconds { get; set; }

        /// <summary>Seconds until the daily rate limit resets.</summary>
        public int? DailyResetSeconds { get; set; }

        /// <summary>Seconds to wait before retrying (from Retry-After header).</summary>
        public int? RetryAfter { get; set; }

        /// <summary>Rate limit policy description (from RateLimit-Policy header).</summary>
        public string RateLimitPolicy { get; set; }

        /// <summary>Current rate limit status (from RateLimit header).</summary>
        public string RateLimitValue { get; set; }
    }
}
