using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Bulk : Service
    {
        private static readonly string[] ValidTypes = { "search", "similar", "company", "finder", "enrich", "linkedin", "author", "verifier", "phone-finder", "phone-validator" };

        private void ValidateType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new TombaException("Missing required parameter: \"type\"");
            }
            if (System.Array.IndexOf(ValidTypes, type) < 0)
            {
                throw new TombaException(
                    $"Invalid bulk type: \"{type}\". Must be one of: {string.Join(", ", ValidTypes)}"
                );
            }
        }

        public Bulk(Client client) : base(client) { }

        /// <summary>
        /// Returns a paginated list of bulk tasks for the given type.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulks">List Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type (e.g., "domain-search", "email-finder", "email-verifier")</param>
        /// <param name="parameters">Optional query parameters (e.g., page, limit)</param>
        /// <returns>Bulk list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ListAsync(string type, Dictionary<string, object> parameters = null)
        {
            ValidateType(type);

            string path = "/bulk/{type}".Replace("{type}", type);

            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Returns a specific bulk task by type and ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk#get-bulk">Get Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task</param>
        /// <returns>Bulk task response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> GetAsync(string type, string id)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}".Replace("{type}", type).Replace("{id}", id);

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
        /// Creates a new bulk task.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Create Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="data">Dictionary of bulk task data</param>
        /// <returns>Create bulk response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CreateAsync(string type, Dictionary<string, object> data)
        {
            ValidateType(type);

            string path = "/bulk/{type}".Replace("{type}", type);

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, data);
        }

        /// <summary>
        /// Launches a bulk task for processing.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Launch Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task to launch</param>
        /// <returns>Launch bulk response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> LaunchAsync(string type, string id)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}/launch".Replace("{type}", type).Replace("{id}", id);

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
        /// Deletes a bulk task by type and ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Delete Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task to delete</param>
        /// <returns>Delete bulk response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DeleteAsync(string type, string id)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}".Replace("{type}", type).Replace("{id}", id);

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
        /// Archives a bulk task by type and ID.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Archive Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task to archive</param>
        /// <returns>Archive bulk response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ArchiveAsync(string type, string id)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}/archive".Replace("{type}", type).Replace("{id}", id);

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
        /// Renames a bulk task.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Rename Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task to rename</param>
        /// <param name="name">The new name for the bulk task</param>
        /// <returns>Rename bulk response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> RenameAsync(string type, string id, string name)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}/rename".Replace("{type}", type).Replace("{id}", id);

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

        /// <summary>
        /// Returns the progress of a bulk task.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Bulk Progress API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task</param>
        /// <returns>Bulk progress response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ProgressAsync(string type, string id)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}/progress".Replace("{type}", type).Replace("{id}", id);

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
        /// Downloads the results of a completed bulk task.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/bulk">Download Bulk API</see>
        /// </remarks>
        /// <param name="type">The bulk type</param>
        /// <param name="id">The ID of the bulk task to download</param>
        /// <returns>Bulk download response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> DownloadAsync(string type, string id)
        {
            ValidateType(type);

            string path = "/bulk/{type}/{id}/download".Replace("{type}", type).Replace("{id}", id);

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
