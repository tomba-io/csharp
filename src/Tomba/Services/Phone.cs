using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Phone : Service
    {
        public Phone(Client client) : base(client) { }

        /// <summary>
        /// Finds phone numbers associated with a contact using domain, first name, and last name.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/phone">Phone Finder API</see>
        /// </remarks>
        /// <param name="parameters">Dictionary containing domain, first_name, last_name, and optional country_code</param>
        /// <param name="webhookUrl">Webhook URL for async notifications</param>
        /// <returns>Phone finder response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> FinderAsync(Dictionary<string, object> parameters, string webhookUrl = null)
        {
            string path = "/phone-finder";

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

        /// <summary>
        /// Validates a phone number and returns formatting and carrier information.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/phone#phone-validator">Phone Validator API</see>
        /// </remarks>
        /// <param name="phone">The phone number to validate</param>
        /// <param name="countryCode">Optional ISO country code</param>
        /// <returns>Phone validator response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ValidatorAsync(string phone, string countryCode = null)
        {
            string path = "/phone-validator";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "phone", phone }
            };

            if (!string.IsNullOrEmpty(countryCode))
            {
                parameters.Add("country_code", countryCode);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}
