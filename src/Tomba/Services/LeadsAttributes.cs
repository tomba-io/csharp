using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class LeadsAttributes : Service
    {
        public LeadsAttributes(Client client) : base(client) { }

        /// <summary>
        /// Returns a list of lead attributes.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-attributes">Get Lead Attributes API</see>
        /// </remarks>
        /// <returns>Lead attributes response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetLeadAttributes()
        {
            string path = "/attributes";

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
        /// Deletes a specific lead attribute by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-attributes#delete-a-lead-attribute">Delete Lead Attribute API</see>
        /// </remarks>
        /// <param name="id">The ID of the attribute to delete</param>
        /// <returns>Delete attribute response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DeleteLeadAttribute(string id)
        {
            string path = "/attributes/{id}".Replace("{id}", id);

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
        /// Creates a new lead attribute with the given name and type.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-attributes#create-a-lead-attribute">Create Lead Attribute API</see>
        /// </remarks>
        /// <returns>Create attribute response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CreateLeadAttribute()
        {
            string path = "/attributes";

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
        /// Updates the fields of a lead attribute by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-attributes#update-a-lead-attribute">Update Lead Attribute API</see>
        /// </remarks>
        /// <param name="id">The ID of the attribute to update</param>
        /// <returns>Update attribute response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> UpdateLeadAttribute(string id)
        {
            string path = "/attributes/{id}".Replace("{id}", id);

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
