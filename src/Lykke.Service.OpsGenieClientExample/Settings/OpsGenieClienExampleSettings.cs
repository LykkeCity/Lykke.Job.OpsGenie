using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.OpsGenieClienExample.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OpsGenieClienExampleSettings
    {
        public DbSettings Db { get; set; }

        public string Domain { get; set; }
    }
}
