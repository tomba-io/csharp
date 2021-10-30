
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Keys : Service
    {
        public Keys(Client client) : base(client) { }

        /// <summary>
        /// Get your keys.
        // <a href="https://developer.tomba.io/#keys">keys</a>.
        /// <para>
        /// Returns a list of your keys.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> GetKeys()
        {
            string path = "/keys/{id}";

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
        /// Delete key
        /// <para>
        /// Delete key
        /// </para>
        /// </summary>
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
        /// Create Key
        /// <para>
        /// Create a new Key.
        /// </para>
        /// </summary>
        public async Task<HttpResponseMessage> CreateKey()
        {
            string path = "/keys/{id}";

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
        /// Reset a key
        /// <para>
        /// Rest your key.
        /// </para>
        /// </summary>
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