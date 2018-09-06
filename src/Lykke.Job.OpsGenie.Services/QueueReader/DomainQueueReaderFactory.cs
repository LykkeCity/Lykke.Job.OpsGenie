using System;
using System.Threading.Tasks;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.AzureRepositories.Queue;
using Lykke.Job.OpsGenie.Contract;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.Job.OpsGenie.Services.Mappers;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.Services.QueueReader
{
    public class DomainQueueReaderFactory:IDomainQueueReaderFactory
    {
        private readonly IReloadingManager<string> _connString;
        private readonly ILogFactory _logFactory;
        private readonly IApiAdapterStorage _apiAdapterStorage;

        public DomainQueueReaderFactory(IReloadingManager<string> connString, ILogFactory logFactory, IApiAdapterStorage apiAdapterStorage)
        {
            _connString = connString;
            _logFactory = logFactory;
            _apiAdapterStorage = apiAdapterStorage;
        }

        public IDomainQueueReader Create(string domain)
        {
            return new DomainQueueReader(_connString, domain, _logFactory, ProcessQueueMessage);
        }

        private async Task ProcessQueueMessage(AlertQueueMessage queueMessage)
        {
            var apiAdapter = _apiAdapterStorage.GetOrDefault(queueMessage.Domain);

            try
            {
                await apiAdapter.CreateAlert(queueMessage.MapFromQueueMessage());
            }
            catch (Exception e)
            {
                _logFactory.CreateLog(apiAdapter).Error(e, context: queueMessage);
            }
        }
    }
}
