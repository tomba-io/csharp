using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Similar : Service
    {
        public Similar(Client client) : base(client) { }

        /// <summary>
        /// Returns a list of websites similar to the given domain.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/domain#similar">Similar Websites API</see>
        /// </remarks>
        /// <param name="domain">The domain name to find similar websites for</param>
        /// <returns>Similar websites response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> WebsitesAsync(string domain)
        {
            string path = "/similar";

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
