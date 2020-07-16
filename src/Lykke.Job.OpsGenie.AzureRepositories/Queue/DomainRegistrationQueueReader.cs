using System.Threading.Tasks;
using Autofac;
using Common;
using Lykke.AzureQueueIntegration;
using Lykke.AzureQueueIntegration.Subscriber;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.AzureRepositories.Queue
{
    public class DomainRegistrationQueueReader:IStartable, IStopable
    {
        private readonly AzureQueueSubscriber<AlertDomainRegistrationQueueMessage> _subscriber;
        private readonly IDomainRepository _domainRepository;

        public DomainRegistrationQueueReader(IReloadingManager<string> connString, 
            ILogFactory logFactory, 
            IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;

            _subscriber = new AzureQueueSubscriber<AlertDomainRegistrationQueueMessage>(
                nameof(DomainRegistrationQueueReader),
                new AzureQueueSettings
                {
                    ConnectionString = connString.CurrentValue,
                    QueueName = OpsGenieQueueNames.DomainRegistrationQueueName
                });


            _subscriber.SetLogger(logFactory.CreateLog(_subscriber));
            _subscriber.Subscribe(ProcessQueueMessage);
            _subscriber.SetDeserializer(new OpsGenieDeserializer<AlertDomainRegistrationQueueMessage>());
        }
        
        private async Task ProcessQueueMessage(AlertDomainRegistrationQueueMessage message)
        {
            await _domainRepository.InsertOrReplace(message.Domain);
        }

        public void Start()
        {
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
