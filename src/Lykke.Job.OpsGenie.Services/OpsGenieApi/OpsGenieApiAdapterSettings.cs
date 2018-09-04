﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi
{
    public class OpsGenieApiAdapterSettings
    {
        public string ApiUrl => "https://api.opsgenie.com/";
        public string ApiKey { get; set; }

        public string Domain { get; set; }
    }
}
