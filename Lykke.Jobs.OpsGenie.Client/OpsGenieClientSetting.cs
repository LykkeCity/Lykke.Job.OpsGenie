namespace Lykke.Jobs.OpsGenie.Client
{
    public class OpsGenieClientSetting
    {
        public OpsGenieClientSetting(string domain, string connString)
        {
            Domain = domain;
            ConnString = connString;
        }

        public string Domain { get; }
        public string ConnString { get; }
    }
}
