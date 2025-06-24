using MediatR;
using TaskManager.Application.Queries;
using TaskManager.Application.Service;

namespace TaskManager.Application.Handlers
{
    public class TaskCanBeDoneHandler : IRequestHandler<TaskCanBeDoneQuery, bool>
    {
        private readonly ITaskChange _taskChange;
        public TaskCanBeDoneHandler(ITaskChange taskChange) 
        {
            _taskChange = taskChange;
        }

        public async Task<bool> Handle(TaskCanBeDoneQuery request, CancellationToken cancellationToken)
        {
            return await _taskChange.CanBeDoneAsync(request.Id, cancellationToken);
        }
    }
}
