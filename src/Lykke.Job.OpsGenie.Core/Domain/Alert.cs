using System.Collections.Generic;
using System.Linq;

namespace Lykke.Job.OpsGenie.Core.Domain
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

        public IReadOnlyDictionary<string, object> Details { get; set; }

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
