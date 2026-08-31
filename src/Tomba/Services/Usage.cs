using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Usage : Service
    {
        public Usage(Client client) : base(client) { }

        /// <summary>
        /// Returns your monthly API usage statistics.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/account#retrieve-api-usage">Usage API</see>
        /// </remarks>
        /// <returns>Usage response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetUsage()
        {
            string path = "/usage";

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
