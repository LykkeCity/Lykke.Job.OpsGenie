using System.Linq;
using Autofac;
using Common;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.AzureRepositories;
using Lykke.Job.OpsGenie.AzureRepositories.Queue;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.Job.OpsGenie.Core.Services;
using Lykke.Job.OpsGenie.LifeTime;
using Lykke.Job.OpsGenie.Mappers;
using Lykke.Job.OpsGenie.PeriodicalHandlers;
using Lykke.Job.OpsGenie.PeriodicalHandlers.Functions;
using Lykke.Job.OpsGenie.Services;
using Lykke.Job.OpsGenie.Services.OpsGenieApi;
using Lykke.Job.OpsGenie.Services.QueueReader;
using Lykke.Job.OpsGenie.Settings.JobSettings;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.Modules
{
    public class JobModule : Module
    {
        private readonly OpsGenieSettings _settings;
        private readonly IReloadingManager<OpsGenieSettings> _settingsManager;

        public JobModule(OpsGenieSettings settings, IReloadingManager<OpsGenieSettings> settingsManager)
        {
            _settings = settings;
            _settingsManager = settingsManager;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>()
                .SingleInstance();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>()
                .AutoActivate()
                .SingleInstance();

            builder.Register(c => DomainRepository.Create(_settingsManager.Nested(p => p.Db.DataConnString),
                        c.Resolve<ILogFactory>()))
                .As<IDomainRepository>()
                .SingleInstance();

            builder.RegisterType<DomainQueueReaderFactory>()
                .WithParameter(TypedParameter.From(_settingsManager.Nested(p=>p.Db.DataConnString)))
                .As<IDomainQueueReaderFactory>()
                .SingleInstance();

            builder.RegisterType<ApiAdapterStorage>()
                .WithParameter(TypedParameter.From(
                    _settings.Domains
                        .Select(p => p.ToApiAdapterSettings(_settings.ApiUrl))))

                .WithParameter(TypedParameter.From(new OpsGenieApiAdapterSettings
                {
                    ApiKey = _settings.DefaultDomainApiKey,
                    Domain = "Default",
                    ApiUrl = _settings.ApiUrl
                }))
                .As<IApiAdapterStorage>()
                .SingleInstance();

            builder.RegisterType<DomainQueueReaderHost>()
                .As<IDomainQueueReaderHost>()
                .As<IStopable>()
                .SingleInstance();

            builder.RegisterType<DomainRegistrationQueueReader>()
                .WithParameter(TypedParameter.From(_settingsManager.Nested(p=>p.Db.DataConnString)))
                .As<IStartable>()
                .As<IStopable>()
                .SingleInstance();

            builder.RegisterType<PeriodicalHandlerHost>()
                .As<IStartable>()
                .As<IStopable>()
                .SingleInstance();

            builder.RegisterType<DomainQueueFunctions>()
                .AsSelf()
                .SingleInstance();

        }
    }
}
