using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Lykke.Job.OpsGenie.Core.Services.OpsGenieApi
{
    public class OpsGenieApiAdapterException:Exception
    {
        public OpsGenieApiAdapterException(string message, object context, Exception innerException) 
            : base(message , innerException)
        {
            Context = context;
        }

        public object Context { get; set; }
    }
}
