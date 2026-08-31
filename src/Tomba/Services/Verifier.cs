using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Verifier : Service
    {
        public Verifier(Client client) : base(client) { }

        /// <summary>
        /// Verifies the deliverability of an email address.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/verifier">Email Verifier API</see>
        /// </remarks>
        /// <param name="email">The email address to verify</param>
        /// <param name="webhookUrl">Webhook URL for async notifications</param>
        /// <returns>Email verifier response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> EmailVerifier(string email, string webhookUrl = null)
        {
            string path = "/email-verifier";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "email", email }
            };

            if (!string.IsNullOrEmpty(webhookUrl))
            {
                parameters.Add("webhook_url", webhookUrl);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
