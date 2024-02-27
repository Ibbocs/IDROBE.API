using IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;
using IDrobeAPI.Application.Models.SendQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendQueryController : BaseController
    {
        private readonly ISendQueryService _queryService;
        public SendQueryController(ISendQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpPost("send-collaborating-query")]
        public IActionResult SendCollaboratingQuery([FromForm] SendQueryModel request)
        {
            var data = _queryService.SendQuery(request);
            return StatusCode((int)data.ResponseCode, data);
        }
    }
}
