using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Keys : Service
    {
        public Keys(Client client) : base(client) { }

        /// <summary>
        /// Returns a list of your API keys.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/keys">List Keys API</see>
        /// </remarks>
        /// <returns>Keys list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetKeys()
        {
            string path = "/keys";

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
        /// Gets a specific API key by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/keys#get-key">Get Key API</see>
        /// </remarks>
        /// <param name="id">The ID of the key</param>
        /// <returns>Key details response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetKey(string id)
        {
            string path = "/keys/{id}".Replace("{id}", id);

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
        /// Deletes a specific API key by ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/keys#delete-an-api-key">Delete Key API</see>
        /// </remarks>
        /// <param name="id">The ID of the key to delete</param>
        /// <returns>Delete key response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DeleteKey(string id)
        {
            string path = "/keys/{id}".Replace("{id}", id);

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
        /// Creates a new API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/keys#create-an-api-key">Create Key API</see>
        /// </remarks>
        /// <returns>Create key response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CreateKey()
        {
            string path = "/keys";

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
        /// Resets an existing API key.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/keys#reset-an-api-key">Reset Key API</see>
        /// </remarks>
        /// <param name="id">The ID of the key to reset</param>
        /// <returns>Reset key response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ResetKey(string id)
        {
            string path = "/keys/{id}".Replace("{id}", id);

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
