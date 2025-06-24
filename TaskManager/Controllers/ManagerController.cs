using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;

namespace TaskManager.API.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IMediator _mediator;

        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(request, cancellationToken);
            return Ok(res);
        }
    }
}
