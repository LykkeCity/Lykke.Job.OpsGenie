using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lykke.Service.OpsGenieClienExample.Request
{
    public class AlertRequest
    {   
        /// <summary>
        /// Unique id used to deduplicate message
        /// </summary>
        [Required]
        public Guid AlertId { get; set; }

        /// <summary>
        /// Message of the alert
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Description field of the alert that is generally used to provide a detailed information about the alert.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Custom actions that will be available for the alert.
        /// </summary>
        public ICollection<string> Actions { get; set; }

        /// <summary>
        /// Tags of the alert
        /// </summary>
        public ICollection<string> Tags { get; set; }

        /// <summary>
        /// Map of key-value pairs to use as custom properties of the alert.
        /// </summary>
        public IDictionary<string, object> Details { get; set; }

        /// <summary>
        /// Priority level of the alert. Possible values are P1, P2, P3, P4 and P5
        /// </summary>
        public PriorityLevel Priority { get; set; }

        public enum PriorityLevel
        {
            /// <summary>
            /// Highest
            /// </summary>
            P1,
            P2,
            P3,
            P4,
            /// <summary>
            /// Highest
            /// </summary>
            P5
        }
    }
}
