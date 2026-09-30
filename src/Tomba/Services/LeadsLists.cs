using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class LeadsLists : Service
    {
        public LeadsLists(Client client) : base(client) { }

        /// <summary>
        /// Returns a list of leads lists.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-lists">Get Leads Lists API</see>
        /// </remarks>
        /// <returns>Leads lists response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetLists()
        {
            string path = "/leads_lists";

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
        /// Deletes a specific leads list by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-lists#delete-leads-list">Delete Leads List API</see>
        /// </remarks>
        /// <param name="id">The ID of the list to delete</param>
        /// <returns>Delete list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
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
        /// Creates a new leads list with the given name.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-lists#create-leads-list">Create Leads List API</see>
        /// </remarks>
        /// <param name="name">The name of the list to create</param>
        /// <returns>Create list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CreateList(string name)
        {
            string path = "/leads_lists";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "name", name }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }

        /// <summary>
        /// Updates the fields of a leads list by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/lead-lists#update-leads-list">Update Leads List API</see>
        /// </remarks>
        /// <param name="id">The ID of the list to update</param>
        /// <param name="name">The new name for the list</param>
        /// <returns>Update list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> UpdateListId(string id, string name)
        {
            string path = "/leads_lists/{id}".Replace("{id}", id);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "name", name }
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("PUT", path, headers, parameters);
        }
    };
}
