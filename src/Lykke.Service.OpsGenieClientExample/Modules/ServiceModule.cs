using Autofac;
using Common;
using Lykke.Job.OpsGenie.Client;
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
            builder.RegisterType<OpsGenieJobClient>()
                .WithParameter(TypedParameter.From(new OpsGenieJobClientOptions(domain: _appSettings.CurrentValue.OpsGenieClienExampleService.Domain, 
                    connString: _appSettings.CurrentValue.OpsGenieClient.ConnString)))
                .As<IOpsGenieJobClient>()
                .As<IStartable>()
                .As<IStopable>()
                .SingleInstance();
        }
    }
}
