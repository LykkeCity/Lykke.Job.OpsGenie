using System.Threading.Tasks;
using Lykke.AzureQueueIntegration;
using Lykke.AzureQueueIntegration.Publisher;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Client.Mappers;
using Lykke.Job.OpsGenie.Contract;

namespace Lykke.Job.OpsGenie.Client
{
    public class OpsGenieClient:IOpsGenieClient
    {
        private readonly AzureQueuePublisher<AlertQueueMessage> _alertPublisher;
        private readonly AzureQueuePublisher<AlertDomainRegistrationQueueMessage> _domainRegistrationPublisher;
        private bool _started;

        private readonly string _domain;

        public OpsGenieClient(OpsGenieClientOptions options,
            ILogFactory logFactory)
        {
            _alertPublisher = new AzureQueuePublisher<AlertQueueMessage>(logFactory, 
                new OpsGenieSerializer<AlertQueueMessage>(),
                publisherName: $"AlertQueueMessagePublisher-{_domain}", 
                settings: new AzureQueueSettings
                {
                    ConnectionString = options.ConnString,
                    QueueName = OpsGenieQueueNames.GenerateAlertMessageQueueName(options.Domain) 
                });

            _domainRegistrationPublisher = new AzureQueuePublisher<AlertDomainRegistrationQueueMessage>(logFactory,
                new OpsGenieSerializer<AlertDomainRegistrationQueueMessage>(),
                publisherName: $"AlertDomainRegistrationQueueMessagePublisher-{_domain}",
                settings: new AzureQueueSettings
                {
                    ConnectionString = options.ConnString,
                    QueueName = OpsGenieQueueNames.DomainRegistrationQueueName
                });

            _domain = options.Domain;
        }

        public async Task CreateAlert(Alert alert)
        {
            Start();

            await _alertPublisher.ProduceAsync(alert.MapToQueueMessage(_domain));
        }

        public void Start()
        {
            if (!_started)
            {
                _domainRegistrationPublisher.Start();
                _alertPublisher.Start();

                //fire n forget
                _domainRegistrationPublisher.
                    ProduceAsync(new AlertDomainRegistrationQueueMessage { Domain = _domain });

                _started = true;
            }
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
