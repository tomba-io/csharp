namespace Tomba
{
    /// <summary>
    /// Base class for all Tomba API service classes.
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// The HTTP client used for API communication.
        /// </summary>
        protected readonly Client _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="client">The Tomba client instance</param>
        public Service(Client client)
        {
            this._client = client;
        }
    }
}
