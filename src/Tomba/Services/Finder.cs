
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Finder : Service
    {
        public Finder(Client client) : base(client) { }

        /// <summary>
        /// Email Finder
        // <a href="https://docs.tomba.io/api/finder#email-finder">Email Finder</a>.
        /// <para>
        /// generates or retrieves the most likely email address from a domain name, a
        /// first name and a last name.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> EmailFinder(string domain, string firstName, string lastName)
        {
            string path = "/email-finder/{domain}".Replace("{domain}", domain);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "first_name", firstName },
                { "last_name", lastName }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }
    };
}