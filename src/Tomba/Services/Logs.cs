using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Logs : Service
    {
        public Logs(Client client) : base(client) { }

        /// <summary>
        /// Returns your last 1,000 requests made during the last 3 months.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/account#retrieve-api-logs">Logs API</see>
        /// </remarks>
        /// <param name="page">Page number for pagination</param>
        /// <param name="limit">Number of results per page</param>
        /// <returns>Logs response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetLogs(int? page = null, int? limit = null)
        {
            string path = "/logs";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            if (limit.HasValue)
            {
                parameters.Add("limit", limit.Value);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
