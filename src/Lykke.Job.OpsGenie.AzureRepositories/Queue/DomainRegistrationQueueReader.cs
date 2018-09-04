using System;
using System.Threading.Tasks;
using Autofac;
using AzureStorage.Queue;
using Common;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.AzureRepositories.Queue
{
    public class DomainRegistrationQueueReader:IStartable, IStopable
    {
        private readonly QueueReader _queueReader;
        private readonly IDomainRepository _domainRepository;

        public DomainRegistrationQueueReader(IReloadingManager<string> connString, 
            ILogFactory logFactory,
            TimeSpan timer, IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
            _queueReader = new QueueReader(AzureQueueExt.Create(connString, QueueNames.DomainRegistrationQueue),
                "DomainQueueRegistration",
                timer, 
                logFactory);

            _queueReader.RegisterHandler(AlertDomainRegistrationQueueMessage.Id, ProcessQueueMessage);
        }


        private async Task ProcessQueueMessage(AlertDomainRegistrationQueueMessage message)
        {
            await _domainRepository.InsertOrReplace(message.Domain);
        }

        public void Start()
        {
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
