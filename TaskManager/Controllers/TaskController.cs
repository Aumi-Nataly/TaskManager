using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;

namespace TaskManager.API.Controllers
{

    public class TaskController : Controller
    {
        private readonly IMediator _mediator;


        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        { 
            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }

    }
}
