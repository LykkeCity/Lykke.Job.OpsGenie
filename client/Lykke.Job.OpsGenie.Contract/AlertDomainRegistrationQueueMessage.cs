using JetBrains.Annotations;
using ProtoBuf;

namespace Lykke.Job.OpsGenie.Contract
{
    /// <summary>
    /// Domain registration
    /// </summary>
    [ProtoContract]
    [PublicAPI]
    public class AlertDomainRegistrationQueueMessage
    {
        /// <summary>
        /// Domain name
        /// </summary>
        [ProtoMember(1)]
        public string Domain { get; set; }
    }
}
