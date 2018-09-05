using Autofac;
using Common;
using Lykke.Jobs.OpsGenie.Client;
using Lykke.Service.OpsGenieClienExample.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.OpsGenieClienExample.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OpsGenieClient>()
                .WithParameter(TypedParameter.From(new OpsGenieClientOptions(domain: "BIL", 
                    connString: _appSettings.CurrentValue.OpsGenieClient.ConnString)))
                .As<IOpsGenieClient>()
                .As<IStartable>()
                .As<IStopable>()
                .SingleInstance();
        }
    }
}
