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
        private readonly TimeSpan _queueTimer;
        private readonly IApiAdapterStorage _apiAdapterStorage;

        public DomainQueueReaderFactory(IReloadingManager<string> connString, ILogFactory logFactory, IApiAdapterStorage apiAdapterStorage)
        {
            _connString = connString;
            _logFactory = logFactory;
            _apiAdapterStorage = apiAdapterStorage;
            _queueTimer = TimeSpan.FromMinutes(1);
        }

        public IDomainQueueReader Create(string domain)
        {
            return new DomainQueueReader(_connString, domain, _logFactory, ProcessQueueMessage, _queueTimer);
        }

        private async Task ProcessQueueMessage(AlertQueueMessage queueMessage)
        {
            var apiAdapter = _apiAdapterStorage.GetOrDefault(queueMessage.Domain);

            await apiAdapter.CreateAlert(queueMessage.MapFromAlertQueueMessage());
        }
    }
}
