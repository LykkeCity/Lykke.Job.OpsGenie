using Lykke.Job.OpsGenie.Services.OpsGenieApi;
using Lykke.Job.OpsGenie.Settings.JobSettings;

namespace Lykke.Job.OpsGenie.Mappers
{
    public static class DomainMapperExtension
    {
        public static OpsGenieApiAdapterSettings ToApiAdapterSettings(this OpsGenieDomain opsGenieDomain)
        {
            return new OpsGenieApiAdapterSettings
            {
                Domain = opsGenieDomain.Name,
                ApiKey = opsGenieDomain.ApiKey
            };
        }
    }
}
