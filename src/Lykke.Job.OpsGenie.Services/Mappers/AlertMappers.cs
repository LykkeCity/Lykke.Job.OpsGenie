using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Job.OpsGenie.Core.Services.OpsGenieApi;
using Lykke.Job.OpsGenie.Services.OpsGenieApi.Contracts;

namespace Lykke.Job.OpsGenie.Services.Mappers
{
    internal static class AlertMappers
    {
        public static Alert MapFromAlertQueueMessage(this AlertQueueMessage alert)
        {
            return new Alert
            {
                Actions = alert.Actions,
                Source = $"{alert.AppName}:{alert.Version}-{alert.EnvInfo}",
                Alias = alert.AlertId.ToString(),
                Tags = alert.Tags,
                Message = alert.Message,
                Description = alert.Description,
                Details = alert.Details,
                Entity = alert.Domain,
                User = alert.AppName
            };
        }

        public static CreateAlertRequestContract MapToCreateAlertContract(this Alert alert)
        {
            return new CreateAlertRequestContract
            {
                Actions = alert.Actions,
                Alias = alert.Alias,
                Description = alert.Description,
                Details = alert.Details,
                Entity = alert.Entity,
                Message = alert.Message,
                Tags = alert.Tags,
                User = alert.User,
                Source = alert.Source
            };
        }
    }
}
