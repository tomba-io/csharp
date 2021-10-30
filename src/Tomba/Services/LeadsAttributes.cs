
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class LeadsAttributes : Service
    {
        public LeadsAttributes(Client client) : base(client) { }

        /// <summary>
        /// Get Lead Attributes
        /// <para>
        /// Returns a list of Lead Attributes.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetLeadAttributes()
        {
            string path = "/leads/attributes/{id}";

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
        /// Delete Lead Attribute
        /// <para>
        /// Delete a specific Attributes by passing id.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> DeleteLeadAttribute(string id)
        {
            string path = "/leads/attributes/{id}".Replace("{id}", id);

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
        /// Create Lead Attribute
        /// <para>
        /// Create a new Attributes with the name and type request parameter.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateLeadAttribute()
        {
            string path = "/leads/attributes/{id}";

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
        /// Update Lead Attribute
        /// <para>
        /// Update the fields of a Attributes using id.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> UpdateLeadAttribute(string id)
        {
            string path = "/leads/attributes/{id}".Replace("{id}", id);

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