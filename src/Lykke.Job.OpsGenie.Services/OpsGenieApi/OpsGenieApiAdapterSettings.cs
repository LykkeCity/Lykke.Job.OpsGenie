using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi
{
    public class OpsGenieApiAdapterSettings
    {
        public string ApiUrl => "https://api.opsgenie.com/v2/alerts";
        public string ApiKey { get; set; }
    }
}
