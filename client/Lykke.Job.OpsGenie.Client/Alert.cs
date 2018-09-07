using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Lykke.Job.OpsGenie.Client
{
    /// <summary>
    /// Alert publishing object
    /// </summary>
    [PublicAPI]
    public class Alert
    {
        /// <summary>
        /// Alert publishing object ctor
        /// </summary>
        /// <param name="alertId">Unique id used to deduplicate message</param>
        /// <param name="message"> Message of the alert</param>
        /// <param name="description"> Description field of the alert that is generally used to provide a detailed information about the alert.</param>
        /// <param name="actions"> Custom actions that will be available for the alert.</param>
        /// <param name="tags"> Tags of the alert</param>
        /// <param name="details"> Map of key-value pairs to use as custom properties of the alert.</param>
        /// <param name="priorityLevel">  Priority level of the alert</param>
        public Alert(Guid alertId, 
            string message, 
            string description = null, 
            ISet<string> actions = null,
            ISet<string> tags = null,
            IDictionary<string, object> details = null,
            PriorityLevel priorityLevel = PriorityLevel.P3)
        {
            AlertId = alertId;
            Message = message ?? throw new ArgumentNullException();

            Actions = actions;
            Tags = tags ;
            Priority = priorityLevel;
            Description = description;
            Details = details;
        }

        /// <summary>
        /// Unique id used to deduplicate message
        /// </summary>
        public Guid AlertId { get; }

        /// <summary>
        /// Message of the alert
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Description field of the alert that is generally used to provide a detailed information about the alert.
        /// </summary>
        public string Description { get;  }

        /// <summary>
        /// Custom actions that will be available for the alert.
        /// </summary>
        public ISet<string> Actions { get;  }

        /// <summary>
        /// Tags of the alert
        /// </summary>
        public ISet<string> Tags { get; }

        /// <summary>
        /// Map of key-value pairs to use as custom properties of the alert.
        /// </summary>
        public IDictionary<string, object> Details { get; }

        /// <summary>
        /// Priority level of the alert. Possible values are P1, P2, P3, P4 and P5
        /// </summary>
        public PriorityLevel Priority { get; }
        
        /// <summary>
        /// Priority level values
        /// </summary>
        public enum PriorityLevel
        {
            /// <summary>
            /// Critical
            /// </summary>
            P1,
            /// <summary>
            /// High
            /// </summary>
            P2,
            /// <summary>
            /// Moderate
            /// </summary>
            P3,
            /// <summary>
            /// Low
            /// </summary>
            P4,
            /// <summary>
            /// Informational
            /// </summary>
            P5
        }
    }
}
