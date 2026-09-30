using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Reveal : Service
    {
        public Reveal(Client client) : base(client) { }

        /// <summary>
        /// Searches for companies based on the provided parameters.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/reveal">Companies Search API</see>
        /// </remarks>
        /// <param name="parameters">Dictionary of search parameters (e.g., query, page, limit, filters)</param>
        /// <returns>Companies search response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CompaniesSearchAsync(Dictionary<string, object> parameters)
        {
            string path = "/reveal/search";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }
    };
}
