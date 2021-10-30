
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Account : Service
    {
        public Account(Client client) : base(client) { }

        /// <summary>
        /// Get Account
        //  <a href="https://developer.tomba.io/#account-information">Account Information</a>.
        /// <para>
        /// Returns information about the current account.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetAccount()
        {
            string path = "/me";

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