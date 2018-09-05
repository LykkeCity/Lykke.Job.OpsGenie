using System;

namespace Lykke.Jobs.OpsGenie.Client
{
    public class OpsGenieClientOptions
    {
        public OpsGenieClientOptions(string domain, string connString)
        {
            Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            ConnString = connString ?? throw new ArgumentNullException(nameof(connString));
        }

        public string Domain { get; }

        public string ConnString { get; }
    }
}
