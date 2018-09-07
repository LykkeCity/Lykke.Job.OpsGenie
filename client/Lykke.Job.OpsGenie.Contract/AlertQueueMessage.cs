using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ProtoBuf;

namespace Lykke.Job.OpsGenie.Contract
{    
    /// <summary>
    /// Alert publishing object
    /// </summary>
    [PublicAPI]
    [ProtoContract]
    public class AlertQueueMessage
    {
        /// <summary>
        /// Unique id used to deduplicate message
        /// </summary>
        [ProtoMember(1)]
        public Guid AlertId { get; set; }

        /// <summary>
        /// Message of the alert
        /// </summary>
        [ProtoMember(2)]
        public string Message { get; set; }

        /// <summary>
        /// Description field of the alert that is generally used to provide a detailed information about the alert.
        /// </summary>
        [ProtoMember(3)]
        public string Description { get; set; }

        /// <summary>
        /// Custom actions that will be available for the alert.
        /// </summary>
        [ProtoMember(4)]
        public ICollection<string> Actions { get; set; }

        /// <summary>
        /// Tags of the alert
        /// </summary>
        [ProtoMember(5)]
        public ICollection<string> Tags { get; set; }

        /// <summary>
        /// Domain of the application
        /// </summary>
        [ProtoMember(6)]
        public string Domain { get; set; }

        /// <summary>
        /// Map of key-value pairs to use as custom properties of the alert.
        /// </summary>
        [ProtoMember(7)]
        public IDictionary<string, object> Details { get; set; }

        /// <summary>
        /// Application sender environment info
        /// </summary>
        [ProtoMember(8)]
        public string EnvInfo { get; set; }

        /// <summary>
        /// Application sender version
        /// </summary>
        [ProtoMember(9)]
        public string Version { get; set; }

        /// <summary>
        /// Application sender name
        /// </summary>
        [ProtoMember(10)]
        public string AppName { get; set; }

        /// <summary>
        /// Priority level of the alert. Possible values are P1, P2, P3, P4 and P5
        /// </summary>
        [ProtoMember(11)]
        public PriorityLevel Priority { get; set; }

        /// <summary>
        /// Priority level of the alert
        /// </summary>
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
