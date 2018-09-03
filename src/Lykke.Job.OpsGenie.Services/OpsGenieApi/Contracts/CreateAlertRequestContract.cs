using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi.Contracts
{
    internal class CreateAlertRequestContract
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }

        [JsonProperty("actions")]
        public IEnumerable<string> Actions { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        //[JsonProperty("note")]
        //public string Note { get; set; }


        //[JsonProperty("source")]
        //public string Source { get; set; }

        //[JsonProperty("priority")]
        //public string Priority { get; set; }

        //TODO visibleTo responders
    }
}
