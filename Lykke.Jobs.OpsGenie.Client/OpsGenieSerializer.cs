using System;
using Common;
using Lykke.AzureQueueIntegration.Publisher;

namespace Lykke.Jobs.OpsGenie.Client
{
    public class OpsGenieSerializer<T> : IAzureQueueSerializer<T>
    {
        private const int MaxQueueMessageBase64Size = 49152;

        public string Serialize(T model)
        {
            if (model == null)
                throw new ArgumentNullException();
            var json = model.ToJson();
            if (json.Length > MaxQueueMessageBase64Size)
            {
                do
                {
                    json = model.ToJson();
                }
                while (json.Length > 49152);
            }
            return json;
        }
    }
}
