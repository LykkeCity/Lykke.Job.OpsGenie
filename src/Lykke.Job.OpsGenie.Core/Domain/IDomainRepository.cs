using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Job.OpsGenie.Core.Domain
{
    public interface IDomainRepository
    {
        Task InsertOrReplace(string domain);

        Task<IEnumerable<string>> GetAll();
    }
}
