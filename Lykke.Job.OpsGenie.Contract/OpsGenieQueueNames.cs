namespace Lykke.Job.OpsGenie.Contract
{
    public static class OpsGenieQueueNames
    {
        private const string AlertMessagePrefix = "ops-genie-alerts-";

        public static string GenerateAlertMessageQueueName(string domain)
        {
            return $"{AlertMessagePrefix}-{domain}";
        }

        public const string DomainRegistrationQueueName = "ops-genie-domain-registration";
    }
}
