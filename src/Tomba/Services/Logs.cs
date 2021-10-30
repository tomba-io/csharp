
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Logs : Service
    {
        public Logs(Client client) : base(client) { }

        /// <summary>
        /// get Logs
        /// <para>
        /// Returns a your last 1,000 requests you made during the last 3 months.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetLogs()
        {
            string path = "/logs";

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