using System;

namespace Lykke.Job.OpsGenie.Core.Services.OpsGenieApi
{
    public class OpsGenieApiAdapterException:Exception
    {
        public OpsGenieApiAdapterException(string message, Exception innerException) 
            : base(message , innerException)
        {
        }
    }
}
