using System.Threading.Tasks;

namespace Lykke.Job.OpsGenie.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
