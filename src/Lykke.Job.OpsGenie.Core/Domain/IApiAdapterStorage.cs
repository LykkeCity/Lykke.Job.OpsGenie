using System;
using System.Collections.Generic;
using System.Text;
using Lykke.Job.OpsGenie.Core.Services.OpsGenieApi;

namespace Lykke.Job.OpsGenie.Core.Domain
{
    public interface IApiAdapterStorage
    {
        IOpsGenieApiAdapter GetOrDefault(string domain);
    }
}
