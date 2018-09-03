using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Job.OpsGenie.Contract
{
    public class AlertQueueMessage
    {
        public Guid AlertId { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

        public ICollection<string> Actions { get; set; }

        public ICollection<string> Tags { get; set; }
        
        public string Domain { get; set; }

        public IDictionary<string, object> Details { get; set; }

        public string EnvInfo { get; set; }

        public string Version { get; set; }

        public string AppName { get; set; }
    }
}
