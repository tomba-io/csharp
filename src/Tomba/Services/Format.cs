using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Format : Service
    {
        public Format(Client client) : base(client) { }

        /// <summary>
        /// Returns the email format used by a domain, along with a confidence score.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/finder#email-format">Email Format API</see>
        /// </remarks>
        /// <param name="domain">The domain name to get the email format for</param>
        /// <returns>Email format response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> EmailFormatAsync(string domain)
        {
            string path = "/email-format";

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
