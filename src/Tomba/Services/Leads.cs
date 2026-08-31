using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Leads : Service
    {
        public Leads(Client client) : base(client) { }

        /// <summary>
        /// Returns a paginated list of leads.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/leads">List Leads API</see>
        /// </remarks>
        /// <param name="page">Page number (default 1)</param>
        /// <param name="limit">Number of results per page (default 10)</param>
        /// <param name="domain">Filter leads by domain</param>
        /// <returns>Leads list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ListLeadsAsync(int? page = 1, int? limit = 10, string domain = null)
        {
            string path = "/leads";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "page", page },
                { "limit", limit }
            };

            if (!string.IsNullOrEmpty(domain))
            {
                parameters.Add("domain", domain);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Returns a specific lead by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/leads#retrieve-a-single-lead">Get Lead API</see>
        /// </remarks>
        /// <param name="id">The ID of the lead</param>
        /// <returns>Lead response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetLeadAsync(string id)
        {
            string path = "/leads/{id}".Replace("{id}", id);

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
        /// Creates a new lead.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/leads#create-a-lead">Create Lead API</see>
        /// </remarks>
        /// <param name="data">Dictionary of lead data fields</param>
        /// <returns>Create lead response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CreateLeadAsync(Dictionary<string, object> data)
        {
            string path = "/leads";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, data);
        }

        /// <summary>
        /// Updates an existing lead by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/leads#update-a-lead">Update Lead API</see>
        /// </remarks>
        /// <param name="id">The ID of the lead to update</param>
        /// <param name="data">Dictionary of lead data fields to update</param>
        /// <returns>Update lead response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> UpdateLeadAsync(string id, Dictionary<string, object> data)
        {
            string path = "/leads/{id}".Replace("{id}", id);

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PUT", path, headers, data);
        }

        /// <summary>
        /// Deletes a specific lead by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/leads#delete-a-lead">Delete Lead API</see>
        /// </remarks>
        /// <param name="id">The ID of the lead to delete</param>
        /// <returns>Delete lead response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DeleteLeadAsync(string id)
        {
            string path = "/leads/{id}".Replace("{id}", id);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("DELETE", path, headers, parameters);
        }
    };
}
