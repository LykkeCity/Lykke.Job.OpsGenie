namespace Lykke.Job.OpsGenie.Contract
{
    public class AlertDomainRegistrationQueueMessage
    {
        public const string Id = "AlertDomainRegistrationQueueMessage";
        public string Domain { get; set; }
    }
}
