using System.Collections.Generic;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Job.OpsGenie.Settings.JobSettings
{
    public class OpsGenieSettings
    {
        public string ApiUrl { get; set; }

        public DbSettings Db { get; set; }

        public string DefaultDomainApiKey { get; set; }
        
        [Optional]
        public IEnumerable<OpsGenieDomain> Domains { get; set; } = new List<OpsGenieDomain>();
    }
}
