using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Domain : Service
    {
        public Domain(Client client) : base(client) { }

        /// <summary>
        /// Search emails for a domain. Returns all email addresses found on the internet for a given domain.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/finder#domain-search">Domain Search API</see>
        /// </remarks>
        /// <param name="domain">The domain name to search</param>
        /// <param name="page">Page number (default 1)</param>
        /// <param name="limit">Number of results per page (default 10)</param>
        /// <param name="department">Filter by department</param>
        /// <param name="enrichMobile">Whether to enrich mobile phone data</param>
        /// <param name="webhookUrl">Webhook URL for async notifications</param>
        /// <returns>Domain search response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DomainSearch(string domain, int? page = 1, int? limit = 10, string department = "", bool? enrichMobile = null, string webhookUrl = null)
        {
            string path = "/domain-search";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "domain", domain },
                { "page", page },
                { "limit", limit },
                { "department", department }
            };

            if (enrichMobile.HasValue)
            {
                parameters.Add("enrich_mobile", enrichMobile.Value);
            }

            if (!string.IsNullOrEmpty(webhookUrl))
            {
                parameters.Add("webhook_url", webhookUrl);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
