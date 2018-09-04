using System.Threading.Tasks;

namespace Lykke.Jobs.OpsGenie.Client
{
    public interface IOpsGenieClient
    {
        Task CreateAlert(Alert alert);
    }
}
