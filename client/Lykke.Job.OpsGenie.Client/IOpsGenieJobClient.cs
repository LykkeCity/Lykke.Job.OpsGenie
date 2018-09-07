using System.Threading.Tasks;
using Autofac;
using Common;
using JetBrains.Annotations;

namespace Lykke.Job.OpsGenie.Client
{
    /// <summary>
    /// Ops genit job client
    /// </summary>
    [PublicAPI]
    public interface IOpsGenieJobClient : IStartable, IStopable
    {
        /// <summary>
        /// Pass alert message to ops genie service
        /// </summary>
        /// <param name="alert">alert message data</param>
        /// <returns></returns>
        Task RiseAlertAsync(Alert alert);
    }
}
