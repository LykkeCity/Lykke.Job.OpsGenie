using System.Threading.Tasks;
using Lykke.Common.Log;
using Lykke.Job.OpsGenie.Core.Services;
using Lykke.Job.OpsGenie.PeriodicalHandlers;

namespace Lykke.Job.OpsGenie.LifeTime
{
    public class StartupManager : IStartupManager
    {
        public async Task StartAsync()
        {

            await Task.CompletedTask;
        }
    }
}
