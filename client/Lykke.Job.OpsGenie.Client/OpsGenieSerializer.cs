using System;
using Common;
using Lykke.AzureQueueIntegration.Publisher;

namespace Lykke.Job.OpsGenie.Client
{
    internal class OpsGenieSerializer<T> : IAzureQueueSerializer<T>
    {
        private const int MaxQueueMessageBase64Size = 49152;

        public string Serialize(T model)
        {
            return model.ToJson(ignoreNulls: true);
        }
    }
}
