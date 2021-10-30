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
    public class Client
    {
        private readonly HttpClient http;

        private readonly Dictionary<string, string> headers;

        private readonly Dictionary<string, string> config;

        private string endPoint;

        private bool selfSigned;

        public Client() :
            this("https://api.tomba.io/v1", false, new HttpClient())
        {
        }

        public Client(string endPoint, bool selfSigned, HttpClient http)
        {
            this.endPoint = endPoint;
            this.selfSigned = selfSigned;
            this.headers =
                new Dictionary<string, string>()
                {
                    { "content-type", "application/json" },
                    { "x-sdk-version", "tomba:dotnet:v1.0.0" }
                };
            this.config = new Dictionary<string, string>();
            this.http = http;
        }

        public Client SetSelfSigned(bool selfSigned)
        {
            this.selfSigned = selfSigned;
            return this;
        }

        public Client SetEndPoint(string endPoint)
        {
            this.endPoint = endPoint;
            return this;
        }

        public string GetEndPoint()
        {
            return endPoint;
        }

        public Dictionary<string, string> GetConfig()
        {
            return config;
        }

        /// <summary>Your Key</summary>
        public Client SetKey(string value)
        {
            config.Add("key", value);
            AddHeader("X-Tomba-Key", value);
            return this;
        }

        /// <summary>Your Secret</summary>
        public Client SetSecret(string value)
        {
            config.Add("secret", value);
            AddHeader("X-Tomba-Secret", value);
            return this;
        }

        public Client AddHeader(String key, String value)
        {
            headers.Add(key, value);
            return this;
        }

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
    }
}
