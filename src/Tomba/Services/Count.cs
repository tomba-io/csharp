using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Count : Service
    {
        public Count(Client client) : base(client) { }

        /// <summary>
        /// Returns the total number of email addresses found for a domain.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/finder#email-count">Email Count API</see>
        /// </remarks>
        /// <param name="domain">The domain name to get the email count for</param>
        /// <returns>Email count response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
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
