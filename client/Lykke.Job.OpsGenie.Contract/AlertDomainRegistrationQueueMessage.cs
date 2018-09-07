using ProtoBuf;

namespace Lykke.Job.OpsGenie.Contract
{
    [ProtoContract]
    public class AlertDomainRegistrationQueueMessage
    {
        [ProtoMember(1)]
        public string Domain { get; set; }
    }
}
