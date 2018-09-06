using System;
using Lykke.Job.OpsGenie.Contract;
using Microsoft.Extensions.PlatformAbstractions;

namespace Lykke.Jobs.OpsGenie.Client.Mappers
{
    internal static class AlertMappers
    {
        public static AlertQueueMessage MapToAlertQueueMessage(this Alert alert, string domain)
        {
            return new AlertQueueMessage
            {
                AlertId = alert.AlertId,
                Message = alert.Message,
                Description = alert.Description,
                Tags = alert.Tags,
                Actions = alert.Actions,
                Details = alert.Details,
                EnvInfo = Environment.GetEnvironmentVariable("ENV_INFO"),
                Version = PlatformServices.Default.Application.ApplicationVersion,
                AppName = PlatformServices.Default.Application.ApplicationName,
                Domain = domain
            };
        }
    }
}
