using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Technology : Service
    {
        public Technology(Client client) : base(client) { }

        /// <summary>
        /// Returns a list of technologies used by the given domain.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/domain#technology">Technology API</see>
        /// </remarks>
        /// <param name="domain">The domain name to detect technologies for</param>
        /// <returns>Technology list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ListAsync(string domain)
        {
            string path = "/technology/{domain}".Replace("{domain}", domain);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
