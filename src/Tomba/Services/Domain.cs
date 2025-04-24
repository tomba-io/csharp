
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Domain : Service
    {
        public Domain(Client client) : base(client) { }

        /// <summary>
        /// Domain Search
        // <a href="https://docs.tomba.io/api/finder#domain-search">Domain Search</a>.
        /// <para>
        /// You can use this endpoint to show different browser icons to your users.
        /// The code argument receives the browser code as it appears in your user
        /// /account/sessions endpoint. Use width, height and quality arguments to
        /// change the output settings.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DomainSearch(string domain, int? page = 1, int? limit = 10, string department = "")
        {
            string path = "/domain-search/{domain}".Replace("{domain}", domain);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "page", page },
                { "limit", limit },
                { "department", department }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}