using System;
using System.Threading.Tasks;
using Lykke.AzureQueueIntegration;
using Lykke.AzureQueueIntegration.Subscriber;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.AzureRepositories.Queue
{
    public class DomainQueueReader:IDomainQueueReader
    {
        private readonly AzureQueueSubscriber<AlertQueueMessage> _subscriber;

        public DomainQueueReader(IReloadingManager<string> connString, string domain, ILogFactory logFactory, Func<AlertQueueMessage, Task> processQueueMessage)
        {
            _subscriber = new AzureQueueSubscriber<AlertQueueMessage>(
                $"DomainQueueReader-{domain}",
                new AzureQueueSettings
                {
                    ConnectionString = connString.CurrentValue,
                    QueueName = OpsGenieQueueNames.GenerateAlertMessageQueueName(domain)
                });

            _subscriber.SetLogger(logFactory.CreateLog(_subscriber));
            _subscriber.Subscribe(processQueueMessage);

            _subscriber.Start();
        }

        public void Dispose()
        {
            _subscriber.Dispose();
        }

        public void Stop()
        {
            _subscriber.Stop();
        }
    }
}
