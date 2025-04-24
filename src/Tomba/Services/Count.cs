
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Count : Service
    {
        public Count(Client client) : base(client) { }

        /// <summary>
        /// get Email Count
        // <a href="https://docs.tomba.io/api/~endpoints#email-count">Email Count</a>.
        /// <para>
        /// Domain name from which you want to find the email addresses.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> EmailCount(string domain)
        {
            string path = "/email-count";

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
    };
}