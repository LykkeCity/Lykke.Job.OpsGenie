
using System.Threading.Tasks;
using Lykke.Common.ApiLibrary.Contract;
using Lykke.Job.OpsGenie.Client;
using Lykke.Service.OpsGenieClienExample.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.OpsGenieClienExample.Controllers
{
    public class AlertController:Controller
    {
        private readonly IOpsGenieClient _opsGenieClient;

        public AlertController(IOpsGenieClient opsGenieClient)
        {
            _opsGenieClient = opsGenieClient;
        }

        [SwaggerOperation()]
        [HttpPost("api/alert")]
        public async Task<IActionResult> WriteAlert(AlertRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponseFactory.Create(ModelState));
            }

            await _opsGenieClient.CreateAlert(new Alert(request.AlertId, request.Message)
            {
                Actions = request.Actions,
                Description = request.Description,
                Details = request.Details,
                Tags = request.Tags,
                Priority = (Alert.PriorityLevel) request.Priority
            });
            return Ok();
        }
    }
}
