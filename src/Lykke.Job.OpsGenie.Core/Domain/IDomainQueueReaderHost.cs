using System;
using Autofac;
using Common;

namespace Lykke.Job.OpsGenie.Core.Domain
{
    public interface IDomainQueueReaderHost: IStopable
    {
        void StartQueueReaderIfNotStarted(string domain);
    }
}
