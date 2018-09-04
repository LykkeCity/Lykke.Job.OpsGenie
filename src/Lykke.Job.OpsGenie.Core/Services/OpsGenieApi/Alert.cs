using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lykke.Job.OpsGenie.Core.Services.OpsGenieApi
{
    public class Alert
    {
        public Alert()
        {
            Actions = Enumerable.Empty<string>();
            Tags = Enumerable.Empty<string>();
            Details = new Dictionary<string, object>();
        }

        public string Message { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<string> Actions { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string Entity { get; set; }

        public string Alias { get; set; }

        public string User { get; set; }

        public string Source { get; set; }

        public IDictionary<string, object> Details { get; set; }
    }
}
