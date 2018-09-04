using System.Collections.Generic;
using System.Linq;
using Lykke.Job.OpsGenie.Core.Domain;
using Lykke.Job.OpsGenie.Core.Services.OpsGenieApi;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi
{
    public class ApiAdapterStorage:IApiAdapterStorage
    {
        private readonly IReadOnlyDictionary<string, IOpsGenieApiAdapter> _adapters;
        private readonly IOpsGenieApiAdapter _defaultApiAdapter;

        public ApiAdapterStorage(IEnumerable<OpsGenieApiAdapterSettings> adapterSettingses, 
            IOpsGenieApiAdapter defaultApiAdapter)
        {
            _defaultApiAdapter = defaultApiAdapter;
            _adapters = adapterSettingses.ToDictionary(p => p.Domain, CreateApiAdapter);
        }


        public IOpsGenieApiAdapter GetOrDefault(string domain)
        {
            return _adapters.ContainsKey(domain) ? _adapters[domain] : _defaultApiAdapter;
        }

        private IOpsGenieApiAdapter CreateApiAdapter(OpsGenieApiAdapterSettings settings)
        {
            return new OpsGenieApiAdapter(settings);
        }
    }
}
