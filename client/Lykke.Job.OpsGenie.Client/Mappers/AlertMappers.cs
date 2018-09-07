using Lykke.Common;
using Lykke.Job.OpsGenie.Contract;

namespace Lykke.Job.OpsGenie.Client.Mappers
{
    internal static class AlertMappers
    {
        public static AlertQueueMessage MapToQueueMessage(this Alert alert, string domain)
        {
            return new AlertQueueMessage
            {
                AlertId = alert.AlertId,
                Message = alert.Message,
                Description = alert.Description,
                Tags = alert.Tags,
                Actions = alert.Actions,
                Details = alert.Details,
                EnvInfo = AppEnvironment.EnvInfo,
                Version = AppEnvironment.Version,
                AppName = AppEnvironment.Name,
                Domain = domain
            };
        }
    }
}
