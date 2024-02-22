using IDrobeAPI.Application.Features.SendQueries.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendQueryController : BaseController
    {
        [HttpPost("send-collaborating-query")]
        public async Task<IActionResult> SendCollaboratingQuery([FromForm] CreateSendQueryCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }
    }
}
