
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Verifier : Service
    {
        public Verifier(Client client) : base(client) { }

        /// <summary>
        /// Email Verifier
        // <a href="https://docs.tomba.io/api/verifier#email-verifier">Email Verifier</a>.
        /// <para>
        /// verify the deliverability of an email address.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> EmailVerifier(string email)
        {
            string path = "/email-verifier/{email}".Replace("{email}", email);

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