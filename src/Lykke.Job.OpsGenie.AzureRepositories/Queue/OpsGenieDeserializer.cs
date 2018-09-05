using Common;
using Lykke.AzureQueueIntegration.Subscriber;

namespace Lykke.Job.OpsGenie.AzureRepositories.Queue
{
    internal class OpsGenieDeserializer<T>: IAzureQueueMessageDeserializer<T>
    {
        public T Deserialize(string data)
        {
            return data.DeserializeJson<T>();
        }
    }
}
