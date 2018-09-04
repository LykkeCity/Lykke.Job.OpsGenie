using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Lykke.Job.OpsGenie.Core.Domain;

namespace Lykke.Job.OpsGenie.Services.QueueReader
{
    public class DomainQueueReaderHost: IDomainQueueReaderHost
    {
        private readonly ConcurrentDictionary<string, Lazy<IDomainQueueReader>> _queueReaders;
        private readonly IDomainQueueReaderFactory _factory;

        public DomainQueueReaderHost(IDomainQueueReaderFactory factory)
        {
            _factory = factory;
            _queueReaders = new ConcurrentDictionary<string, Lazy<IDomainQueueReader>>();
        }
        
        public void StartQueueReaderIfNotStarted(string domain)
        {
            var queue = _queueReaders.GetOrAdd(domain, p =>
            {
                return new Lazy<IDomainQueueReader>(() => _factory.Create(domain));
            }).Value;
        }
        
        public void Dispose()
        {
            Parallel.ForEach(_queueReaders.Values, p => p.Value.Dispose());
        }

        public void Stop()
        {
            Parallel.ForEach(_queueReaders.Values, p => p.Value.Stop());
        }
    }
}
