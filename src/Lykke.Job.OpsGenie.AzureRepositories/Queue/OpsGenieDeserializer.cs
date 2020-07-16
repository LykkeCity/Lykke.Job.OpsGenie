using System;
using System.IO;
using Lykke.AzureQueueIntegration.Subscriber;
using ProtoBuf;

namespace Lykke.Job.OpsGenie.AzureRepositories.Queue
{
    internal class OpsGenieDeserializer<T>: IAzureQueueMessageDeserializer<T>
    {
        public T Deserialize(string data)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(data)))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}
