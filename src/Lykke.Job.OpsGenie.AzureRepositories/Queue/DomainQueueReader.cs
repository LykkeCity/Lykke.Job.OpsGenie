using System;
using System.Threading.Tasks;
using AzureStorage.Queue;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.AzureRepositories.Queue
{
    public class DomainQueueReader:IDomainQueueReader
    {
        private readonly QueueReader _queueReader;

        public DomainQueueReader(IReloadingManager<string> connString, string domain, ILogFactory logFactory, Func<AlertQueueMessage, Task> processQueueMessage, TimeSpan timer)
        {
            _queueReader = new QueueReader(AzureQueueExt.Create(connString, QueueNames.AlertMessagePrefix + domain),
                $"DomainQueueReader-{domain}",
                timer, 
                logFactory);

            _queueReader.RegisterHandler(AlertQueueMessage.Id, processQueueMessage);

            _queueReader.Start();
        }

        public void Dispose()
        {
            _queueReader.Dispose();
        }

        public void Stop()
        {
            _queueReader.Stop();
        }
    }
}
