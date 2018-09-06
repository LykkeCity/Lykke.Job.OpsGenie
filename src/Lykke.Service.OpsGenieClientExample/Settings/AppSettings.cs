using JetBrains.Annotations;
using Lykke.Jobs.OpsGenie.Client;
using Lykke.Sdk.Settings;

namespace Lykke.Service.OpsGenieClienExample.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public OpsGenieClienExampleSettings OpsGenieClienExampleService { get; set; }
        public OpsGenieClientSettings OpsGenieClient { get; set; }
    }
}
