using System;

namespace Lykke.Job.OpsGenie.Client
{
    public class OpsGenieClientOptions
    {
        /// <summary>
        /// Configures ops genie client
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="connString">Connection string readed from OpsGenieClient section in settings</param>
        public OpsGenieClientOptions(string domain, string connString)
        {
            Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            ConnString = connString ?? throw new ArgumentNullException(nameof(connString));
        }

        public string Domain { get; }

        public string ConnString { get; }
    }
}
