using Lykke.SettingsReader.Attributes;

namespace Lykke.Job.OpsGenie.Settings.SlackNotifications
{
    public class AzureQueuePublicationSettings
    {
        [AzureTableCheck]
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}
