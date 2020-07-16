using System.IO;
using Common;
using Lykke.AzureQueueIntegration.Publisher;
using ProtoBuf;

namespace Lykke.Job.OpsGenie.Client
{
    internal class OpsJobGenieSerializer<T> : IAzureQueueSerializer<T>
    {
        public string Serialize(T model)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, model);

                return ms.ToArray().ToBase64();
            }
        }
    }
}
