using System;

namespace Lykke.Job.OpsGenie.Contract
{
    public static class OpsGenieQueueNames
    {
        private const string AlertMessagePrefix = "ops-genie-alerts";

        public static string GenerateAlertMessageQueueName(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentNullException(nameof(domain));
            }

            var sanitazed = domain.ToLowerInvariant().Trim().Replace(" ", "").Replace("-", "");
            return $"{AlertMessagePrefix}-{sanitazed}";
        }

        public const string DomainRegistrationQueueName = "ops-genie-domain-registration";
    }
}
