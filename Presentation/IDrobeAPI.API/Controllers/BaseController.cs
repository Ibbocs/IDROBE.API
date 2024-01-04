using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? _mediator => Mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? Mediator;
    }
}
