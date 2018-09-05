using System.Threading.Tasks;
using Autofac;
using Common;

namespace Lykke.Jobs.OpsGenie.Client
{
    public interface IOpsGenieClient : IStartable, IStopable
    {
        /// <summary>
        /// Pass alert message to ops genie service
        /// </summary>
        /// <param name="alert">alert message data</param>
        /// <returns></returns>
        Task CreateAlert(Alert alert);
    }
}
