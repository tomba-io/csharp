using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Status : Service
    {
        public Status(Client client) : base(client) { }

        /// <summary>
        /// Returns domain status indicating if it is a webmail or disposable domain.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/domain#domain-status">Domain Status API</see>
        /// </remarks>
        /// <param name="domain">The domain name to check status for</param>
        /// <returns>Domain status response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DomainStatus(string domain)
        {
            string path = "/domain-status";

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
        /// Auto-completes company names and retrieves logo and domain information.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/domain-suggestions">Domain Suggestions API</see>
        /// </remarks>
        /// <param name="query">The search query for auto-completion</param>
        /// <returns>Domain suggestions response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> AutoComplete(string query)
        {
            string path = "/domain-suggestions";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "query", query }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
