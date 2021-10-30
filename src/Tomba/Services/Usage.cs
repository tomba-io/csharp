
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Usage : Service
    {
        public Usage(Client client) : base(client) { }

        /// <summary>
        /// get Usage
        /// <para>
        /// Returns a your monthly requests
        /// </para>
        /// </summary>
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