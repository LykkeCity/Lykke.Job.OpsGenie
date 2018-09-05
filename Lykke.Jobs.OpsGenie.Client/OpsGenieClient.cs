using System.Threading.Tasks;
using Lykke.AzureQueueIntegration;
using Lykke.AzureQueueIntegration.Publisher;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Jobs.OpsGenie.Client.Mappers;

namespace Lykke.Jobs.OpsGenie.Client
{
    public class OpsGenieClient:IOpsGenieClient
    {
        private readonly AzureQueuePublisher<AlertQueueMessage> _alertPublisher;
        private readonly AzureQueuePublisher<AlertDomainRegistrationQueueMessage> _domainRegistrationPublisher;

        private readonly string _domain;

        public OpsGenieClient(OpsGenieClientSetting setting,
            ILogFactory logFactory)
        {
            _alertPublisher = new AzureQueuePublisher<AlertQueueMessage>(logFactory, 
                new OpsGenieSerializer<AlertQueueMessage>(),
                publisherName: $"AlertQueueMessagePublisher-{_domain}", 
                settings: new AzureQueueSettings
                {
                    ConnectionString = setting.ConnString,
                    QueueName = OpsGenieQueueNames.GenerateAlertMessageQueueName(setting.Domain) 
                });

            _domainRegistrationPublisher = new AzureQueuePublisher<AlertDomainRegistrationQueueMessage>(logFactory,
                new OpsGenieSerializer<AlertDomainRegistrationQueueMessage>(),
                publisherName: $"AlertDomainRegistrationQueueMessagePublisher-{_domain}",
                settings: new AzureQueueSettings
                {
                    ConnectionString = setting.ConnString,
                    QueueName = OpsGenieQueueNames.DomainRegistrationQueueName
                });

            _domain = setting.Domain;
        }

        public Task CreateAlert(Alert alert)
        {
            return _alertPublisher.ProduceAsync(alert.MapToAlertQueueMessage(_domain));
        }

        public void Start()
        {
            _domainRegistrationPublisher.Start();
            _alertPublisher.Start();

            //fire n forget
            _domainRegistrationPublisher.
                ProduceAsync(new AlertDomainRegistrationQueueMessage {Domain = _domain});
        }

        public void Dispose()
        {
            _domainRegistrationPublisher.Dispose();
            _alertPublisher.Dispose();
        }

        public void Stop()
        {
            _domainRegistrationPublisher.Stop();
            _alertPublisher.Stop();
        }
    }
}
