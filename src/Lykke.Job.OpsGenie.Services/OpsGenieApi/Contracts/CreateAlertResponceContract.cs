using Newtonsoft.Json;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi.Contracts
{
    internal class CreateAlertResponceContract
    {
        public string RequestId { get; set; }

        public double Took { get; set; }

        public string Result { get; set; }
    }
}
