
using System.Linq;
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
        private readonly IOpsGenieJobClient _opsGenieJobClient;

        public AlertController(IOpsGenieJobClient opsGenieJobClient)
        {
            _opsGenieJobClient = opsGenieJobClient;
        }

        [SwaggerOperation()]
        [HttpPost("api/alert")]
        public async Task<IActionResult> WriteAlert(AlertRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponseFactory.Create(ModelState));
            }

            await _opsGenieJobClient.RiseAlertAsync(new Alert(
                request.AlertId, 
                request.Message,
                description: request.Description,
                actions: request.Actions.Distinct().ToHashSet(),
                tags: request.Tags.Distinct().ToHashSet(),
                priorityLevel: (Alert.PriorityLevel)request.Priority
                ));

            return Ok();
        }
    }
}
