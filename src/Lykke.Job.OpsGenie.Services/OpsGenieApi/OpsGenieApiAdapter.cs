using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Lykke.Job.OpsGenie.Core.Services.OpsGenieApi;
using Lykke.Job.OpsGenie.Services.Mappers;
using Lykke.Job.OpsGenie.Services.OpsGenieApi.Contracts;

namespace Lykke.Job.OpsGenie.Services.OpsGenieApi
{
    public class OpsGenieApiAdapter: IOpsGenieApiAdapter
    {
        private readonly OpsGenieApiAdapterSettings _settings;

        public OpsGenieApiAdapter(OpsGenieApiAdapterSettings settings)
        {
            _settings = settings;
        }

        public async Task<CreateAlertResult> CreateAlert(Alert alert)
        {
            try
            {
                var resp = await _settings.ApiUrl
                    .AppendPathSegment("v2/alerts")
                    .WithHeader("Authorization", $"GenieKey {_settings.ApiKey}")
                    .PostJsonAsync(alert.MapToCreateAlertContract())
                    .ReceiveJson<CreateAlertResponceContract>();

                return new CreateAlertResult
                {
                    RequestId = Guid.Parse(resp.RequestId)
                };
            }
            catch (FlurlHttpException e)
            {
                throw new OpsGenieApiAdapterException($"Error while interaction with OpsGenieApi: " +
                                                      $"{await e.GetResponseStringAsync()}", 
                    alert.MapToCreateAlertContract(), 
                    e);
            }
        }
    }
}
