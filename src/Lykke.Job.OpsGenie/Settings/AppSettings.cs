using Lykke.Job.OpsGenie.Settings.JobSettings;
using Lykke.Job.OpsGenie.Settings.SlackNotifications;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Job.OpsGenie.Settings
{
    public class AppSettings
    {
        public OpsGenieSettings OpsGenieJob { get; set; }

        public SlackNotificationsSettings SlackNotifications { get; set; }

        [Optional]
        public MonitoringServiceClientSettings MonitoringServiceClient { get; set; }
    }
}
