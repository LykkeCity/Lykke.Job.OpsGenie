using System.Collections.Generic;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Job.OpsGenie.Settings.JobSettings
{
    public class OpsGenieSettings
    {
        public DbSettings Db { get; set; }

        public string DefaultDomainApiKey { get; set; }
        
        [Optional]
        public IEnumerable<OpsGenieDomain> SpecificDomains { get; set; } = new List<OpsGenieDomain>();
    }
}
