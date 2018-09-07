using System;
using JetBrains.Annotations;

namespace Lykke.Job.OpsGenie.Contract
{
    /// <summary>
    /// Azure queue names
    /// </summary>
    [PublicAPI]
    public static class OpsGenieQueueNames
    {
        private const string AlertMessagePrefix = "ops-genie-alerts";
        
        /// <summary>
        /// Queue generation for specific domain
        /// </summary>
        /// <param name="domain">application domain</param>
        /// <returns></returns>
        public static string GenerateAlertMessageQueueName(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentNullException(nameof(domain));
            }

            var sanitazed = domain.ToLowerInvariant().Trim().Replace(" ", "").Replace("-", "");
            return $"{AlertMessagePrefix}-{sanitazed}";
        }

        /// <summary>
        /// Domain registration queue
        /// </summary>
        public const string DomainRegistrationQueueName = "ops-genie-domain-registration";
    }
}
