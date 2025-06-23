using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Application.Service;

namespace TaskManager.Application.Handlers
{
    public class ChangeTaskStatusHandler : IRequestHandler<ChangeTaskStatusCommand, Unit>
    {
        private readonly ITaskChange _taskChange;
        public ChangeTaskStatusHandler(ITaskChange taskChange) 
        {
            _taskChange = taskChange;
        }
        public async Task<Unit> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            await _taskChange.ChangeStatusAsync(request.Id, request.Status, cancellationToken);
            return Unit.Value;
        }
    }
}
