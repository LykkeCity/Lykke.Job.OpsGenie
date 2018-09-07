using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.AzureRepositories.Domain;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.SettingsReader;

namespace Lykke.Job.OpsGenie.AzureRepositories
{
    public class DomainRepository: IDomainRepository
    {
        private readonly INoSQLTableStorage<DomainEntity> _storage;

        private DomainRepository(INoSQLTableStorage<DomainEntity> storage)
        {
            _storage = storage;
        }

        public static IDomainRepository Create(IReloadingManager<string> connnectionString, ILogFactory logFactory)
        {
            return new DomainRepository(AzureTableStorage<DomainEntity>.Create(connnectionString, "Domains", logFactory));
        }

        public Task InsertOrReplace(string domain)
        {
            return _storage.InsertOrReplaceAsync(DomainEntity.Create(domain));
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            return (await _storage.GetDataAsync()).Select(p => p.Domain).ToList();
        }
    }
}
