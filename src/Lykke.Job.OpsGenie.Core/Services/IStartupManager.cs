using System.Threading.Tasks;

namespace Lykke.Job.OpsGenie.Core.Services
{
    public interface IStartupManager
    {
        Task StartAsync();
    }
}