using System;
using JetBrains.Annotations;

namespace Lykke.Job.OpsGenie.Client
{
    /// <summary>
    /// Client creation config
    /// </summary>
    [PublicAPI]
    public class OpsGenieJobClientOptions
    {
        /// <summary>
        /// Configures ops genie client
        /// </summary>
        /// <param name="domain">domain of the service - for example "BIL"</param>
        /// <param name="connString">Connection string readed from OpsGenieJobClient section in settings</param>
        public OpsGenieJobClientOptions(string domain, string connString)
        {
            Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            ConnString = connString ?? throw new ArgumentNullException(nameof(connString));
        }

        /// <summary>
        /// domain of the service - for example "BIL"
        /// </summary>
        public string Domain { get; }

        /// <summary>
        /// Connection string readed from OpsGenieJobClient section in settings
        /// </summary>
        public string ConnString { get; }
    }
}
