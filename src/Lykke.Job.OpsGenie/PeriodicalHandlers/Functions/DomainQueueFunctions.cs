using System.Threading.Tasks;
using Lykke.Job.OpsGenie.Core.Domain;

namespace Lykke.Job.OpsGenie.PeriodicalHandlers.Functions
{
    public class DomainQueueFunctions
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IDomainQueueReaderHost _host;

        public DomainQueueFunctions(IDomainRepository domainRepository, IDomainQueueReaderHost host)
        {
            _domainRepository = domainRepository;
            _host = host;
        }

        public async Task Refresh()
        {
            foreach (var domain in await _domainRepository.GetAll())
            {
                _host.StartQueueReaderIfNotStarted(domain);
            }
        }
    }
}
