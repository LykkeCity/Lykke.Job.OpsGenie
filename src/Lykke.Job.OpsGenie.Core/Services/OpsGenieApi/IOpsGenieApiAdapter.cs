using System.Threading.Tasks;
using Lykke.Job.OpsGenie.Core.Domain;

namespace Lykke.Job.OpsGenie.Core.Services.OpsGenieApi
{
    public interface IOpsGenieApiAdapter
    {
        Task<CreateAlertResult> RaiseAlertAsync(Alert alert);
    }
}
