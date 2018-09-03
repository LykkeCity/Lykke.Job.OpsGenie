using Newtonsoft.Json;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi.Contracts
{
    internal class CreateAlertResponceContract
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("took")]
        public double Took { get; set; }

        [JsonProperty("Result")]
        public string Result { get; set; }
    }
}
