
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Sources : Service
    {
        public Sources(Client client) : base(client) { }

        /// <summary>
        /// Email Sources
        // <a href="https://docs.tomba.io/api/~endpoints#email-sources">Email Sources</a>.
        /// <para>
        /// Find email address source somewhere on the web.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> EmailSources(string email)
        {
            string path = "/email-sources/{email}".Replace("{email}", email);

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