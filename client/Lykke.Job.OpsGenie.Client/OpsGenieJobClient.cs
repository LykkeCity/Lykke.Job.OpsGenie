using System;
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

        private Lazy<Task> _initionLocker;

        /// <summary>
        /// OpsGenieJobClient ctor
        /// </summary>
        /// <param name="options">configuration</param>
        /// <param name="logFactory">lykke logging</param>
        public OpsGenieJobClient(OpsGenieJobClientOptions options,
            ILogFactory logFactory)
        {
            _domain = options.Domain;

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

            _initionLocker = new Lazy<Task>(InitInnerAsync);
        }

        /// <summary>
        /// Alert publishing
        /// </summary>
        /// <param name="alert">Published data</param>
        /// <returns></returns>
        public async Task RiseAlertAsync(Alert alert)
        {
            if (alert == null)
            {
                throw new ArgumentNullException(nameof(alert));
            }

            await EnsureInitionAsync();

            await _alertPublisher.ProduceAsync(alert.MapToQueueMessage(_domain));
        }

        /// <summary>
        /// Start client
        /// </summary>
        public void Start()
        {
            EnsureInitionAsync().Wait();
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

        private async Task InitInnerAsync()
        {
            _domainRegistrationPublisher.Start();
            _alertPublisher.Start();
            
            await _domainRegistrationPublisher.ProduceAsync(new AlertDomainRegistrationQueueMessage
                {
                    Domain = _domain
                });
        }

        private Task EnsureInitionAsync()
        {
            return _initionLocker.Value;
        }
    }
}
