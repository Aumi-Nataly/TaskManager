using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.Queries;

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

        [HttpGet("CanBeDone")]
        public async Task<IActionResult> CanBeDone(TaskCanBeDoneQuery request, CancellationToken cancellationToken)
        {
           var res = await _mediator.Send(request, cancellationToken);
            return Ok(res);
        }
    }
}
