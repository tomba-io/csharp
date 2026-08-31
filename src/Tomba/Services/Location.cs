using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Location : Service
    {
        public Location(Client client) : base(client) { }

        /// <summary>
        /// Returns location and company information for a given domain.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/finder#location">Location API</see>
        /// </remarks>
        /// <param name="domain">The domain name to get location for</param>
        /// <returns>Location response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetLocationAsync(string domain)
        {
            string path = "/location/{domain}".Replace("{domain}", domain);

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
