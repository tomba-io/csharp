
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class LeadsLists : Service
    {
        public LeadsLists(Client client) : base(client) { }

        /// <summary>
        /// Get Leads Lists
        /// <para>
        /// Returns a list of leads lists..
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetLists()
        {
            string path = "/leads_lists/{id}";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Delete List ID
        /// <para>
        /// Delete a specific list by passing id.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteListId(string id)
        {
            string path = "/leads_lists/{id}".Replace("{id}", id);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }

        /// <summary>
        /// Create new List
        /// <para>
        /// Create a new leads list with the name request parameter
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateList()
        {
            string path = "/leads_lists/{id}";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Update List ID
        /// <para>
        /// Update the fields of a list using id.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateListId(string id)
        {
            string path = "/leads_lists/{id}".Replace("{id}", id);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PUT", path, headers, parameters);
        }
    };
}