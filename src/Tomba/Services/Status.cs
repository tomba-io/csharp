
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Status : Service
    {
        public Status(Client client) : base(client) { }

        /// <summary>
        /// Domain status
        /// <para>
        /// Returns domain status if is webmail or disposable.
        /// </para>
        /// </summary>
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
        /// get Company Autocomplete
        /// <para>
        /// Company Autocomplete is an API that lets you auto-complete company names
        /// and retrieve logo and domain information.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> AutoComplete(string query)
        {
            string path = "/domains-suggestion";

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