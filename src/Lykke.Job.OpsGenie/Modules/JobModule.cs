﻿using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.AzureRepositories;
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
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Job.OpsGenie.Modules
{
    public class JobModule : Module
    {
        private readonly OpsGenieSettings _settings;
        private readonly IReloadingManager<OpsGenieSettings> _settingsManager;
        private readonly IServiceCollection _services;

        public JobModule(OpsGenieSettings settings, IReloadingManager<OpsGenieSettings> settingsManager)
        {
            _settings = settings;
            _settingsManager = settingsManager;

            _services = new ServiceCollection();
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
                .As<IDomainQueueReaderFactory>()
                .SingleInstance();

            builder.RegisterType<ApiAdapterStorage>()
                .WithParameter(TypedParameter.From(
                    _settings.SpecificDomains
                        .Select(p => p.ToApiAdapterSettings())))

                .WithParameter(TypedParameter.From(
                    _settings.DefaultDomain.ToApiAdapterSettings()))
                .As<IApiAdapterStorage>()
                .SingleInstance();

            builder.RegisterType<DomainQueueReaderHost>()
                .As<IDomainQueueReaderHost>()
                .SingleInstance();

            builder.RegisterType<PeriodicalHandlerHost>()
                .AsSelf()
                .AutoActivate()
                .SingleInstance();

            builder.RegisterType<DomainQueueFunctions>()
                .AsSelf()
                .SingleInstance();
            
            builder.Populate(_services);
        }
    }
}
