using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Lykke.Job.OpsGenie.Contract
{
    [ProtoContract]
    public class AlertQueueMessage
    {
        [ProtoMember(1)]
        public Guid AlertId { get; set; }

        [ProtoMember(2)]
        public string Message { get; set; }

        [ProtoMember(3)]
        public string Description { get; set; }

        [ProtoMember(4)]
        public ICollection<string> Actions { get; set; }

        [ProtoMember(5)]
        public ICollection<string> Tags { get; set; }

        [ProtoMember(6)]
        public string Domain { get; set; }

        [ProtoMember(7)]
        public IDictionary<string, object> Details { get; set; }

        [ProtoMember(8)]
        public string EnvInfo { get; set; }

        [ProtoMember(9)]
        public string Version { get; set; }

        [ProtoMember(10)]
        public string AppName { get; set; }

        [ProtoMember(11)]
        public PriorityLevel Priority { get; set; }

        public enum PriorityLevel
        {
            P1,
            P2,
            P3,
            P4,
            P5
        }
    }
}
