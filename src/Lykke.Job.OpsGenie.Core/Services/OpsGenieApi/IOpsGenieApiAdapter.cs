using System.Threading.Tasks;

namespace Lykke.Job.OpsGenie.Core.Services.OpsGenieApi
{
    public interface IOpsGenieApiAdapter
    {
        Task<CreateAlertResult> CreateAlert(Alert alert);
    }
}
