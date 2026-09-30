using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Finder : Service
    {
        public Finder(Client client) : base(client) { }

        /// <summary>
        /// Generates or retrieves the most likely email address from a domain name, a first name and a last name.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/finder#email-finder">Email Finder API</see>
        /// </remarks>
        /// <param name="domain">The domain name of the company</param>
        /// <param name="firstName">The first name of the person</param>
        /// <param name="lastName">The last name of the person</param>
        /// <param name="webhookUrl">Webhook URL for async notifications</param>
        /// <returns>Email finder response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> EmailFinder(string domain, string firstName, string lastName, string webhookUrl = null)
        {
            string path = "/email-finder";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "domain", domain },
                { "first_name", firstName },
                { "last_name", lastName }
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
