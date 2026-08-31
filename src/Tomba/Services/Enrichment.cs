using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Enrichment : Service
    {
        public Enrichment(Client client) : base(client) { }

        /// <summary>
        /// Returns enriched person data based on an email address.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/enrichment#person-enrichment">Person Enrichment API</see>
        /// </remarks>
        /// <param name="email">The email address to enrich</param>
        /// <param name="webhookUrl">Webhook URL for async notifications</param>
        /// <returns>Person enrichment response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> PersonAsync(string email, string webhookUrl = null)
        {
            string path = "/enrichment/person";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "email", email }
            };

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

        /// <summary>
        /// Returns enriched company data based on a domain name.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/enrichment#company-enrichment">Company Enrichment API</see>
        /// </remarks>
        /// <param name="domain">The domain name to enrich</param>
        /// <returns>Company enrichment response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CompanyAsync(string domain)
        {
            string path = "/enrichment/company";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "domain", domain }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Returns combined person and company enrichment data based on an email address.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/enrichment#combined-enrichment">Combined Enrichment API</see>
        /// </remarks>
        /// <param name="email">The email address for combined enrichment</param>
        /// <returns>Combined enrichment response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CombinedAsync(string email)
        {
            string path = "/enrichment/combined";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "email", email }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
