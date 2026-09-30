using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tomba
{
    public class Flag : Service
    {
        public Flag(Client client) : base(client) { }

        /// <summary>
        /// Returns a list of flagged email addresses.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/flag">List Flags API</see>
        /// </remarks>
        /// <param name="page">Page number for pagination</param>
        /// <param name="limit">Number of results per page</param>
        /// <returns>Flags list response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> ListFlagsAsync(int? page = null, int? limit = null)
        {
            string path = "/flag";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };

            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            if (limit.HasValue)
            {
                parameters.Add("limit", limit.Value);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("GET", path, headers, parameters);
        }

        /// <summary>
        /// Flags incorrect data with the specified type and value.
        /// </summary>
        /// <remarks>
        /// See <see href="https://docs.tomba.io/api/flag#flag-incorrect-data">Create Flag API</see>
        /// </remarks>
        /// <param name="flagType">The type of flag (e.g., email, domain)</param>
        /// <param name="value">The value to flag</param>
        /// <param name="reason">Reason for flagging</param>
        /// <param name="comment">Optional comment</param>
        /// <returns>Create flag response</returns>
        /// <exception cref="TombaException">Thrown on API error</exception>
        public async Task<HttpResponseMessage> CreateFlagAsync(string flagType, string value, string reason, string comment = null)
        {
            string path = "/flag";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "flag_type", flagType },
                { "value", value },
                { "reason", reason }
            };

            if (!string.IsNullOrEmpty(comment))
            {
                parameters.Add("comment", comment);
            }

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };

            return await _client.Call("POST", path, headers, parameters);
        }
    };
}
