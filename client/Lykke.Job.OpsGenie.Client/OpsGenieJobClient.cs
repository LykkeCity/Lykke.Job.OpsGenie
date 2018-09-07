using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.AzureQueueIntegration;
using Lykke.AzureQueueIntegration.Publisher;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Client.Mappers;
using Lykke.Job.OpsGenie.Contract;

namespace Lykke.Job.OpsGenie.Client
{
    /// <summary>
    /// job client
    /// </summary>
    [PublicAPI]
    public class OpsGenieJobClient:IOpsGenieJobClient
    {
        private readonly AzureQueuePublisher<AlertQueueMessage> _alertPublisher;
        private readonly AzureQueuePublisher<AlertDomainRegistrationQueueMessage> _domainRegistrationPublisher;
        private bool _started;

        private readonly string _domain;

        /// <summary>
        /// OpsGenieJobClient ctor
        /// </summary>
        /// <param name="options">configuration</param>
        /// <param name="logFactory">lykke logging</param>
        public OpsGenieJobClient(OpsGenieJobClientOptions options,
            ILogFactory logFactory)
        {
            _alertPublisher = new AzureQueuePublisher<AlertQueueMessage>(logFactory, 
                new OpsJobGenieSerializer<AlertQueueMessage>(),
                publisherName: $"AlertQueueMessagePublisher-{_domain}", 
                settings: new AzureQueueSettings
                {
                    ConnectionString = options.ConnString,
                    QueueName = OpsGenieQueueNames.GenerateAlertMessageQueueName(options.Domain) 
                });

            _domainRegistrationPublisher = new AzureQueuePublisher<AlertDomainRegistrationQueueMessage>(logFactory,
                new OpsJobGenieSerializer<AlertDomainRegistrationQueueMessage>(),
                publisherName: $"AlertDomainRegistrationQueueMessagePublisher-{_domain}",
                settings: new AzureQueueSettings
                {
                    ConnectionString = options.ConnString,
                    QueueName = OpsGenieQueueNames.DomainRegistrationQueueName
                });

            _domain = options.Domain;
        }

        /// <summary>
        /// Alert publishing
        /// </summary>
        /// <param name="alert">Published data</param>
        /// <returns></returns>
        public async Task CreateAlert(Alert alert)
        {
            Start();

            await _alertPublisher.ProduceAsync(alert.MapToQueueMessage(_domain));
        }

        /// <summary>
        /// Start client
        /// </summary>
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

        /// <summary>
        /// Dispose Client
        /// </summary>
        public void Dispose()
        {
            _domainRegistrationPublisher.Dispose();
            _alertPublisher.Dispose();
        }

        /// <summary>
        /// Stop Client
        /// </summary>
        public void Stop()
        {
            _domainRegistrationPublisher.Stop();
            _alertPublisher.Stop();
        }
    }
}
