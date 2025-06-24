using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Application.Service;

namespace TaskManager.Application.Handlers
{
    public class CreateTaskHandler: IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskChange _taskChange;
        public CreateTaskHandler(ITaskChange taskChange) 
        {
            _taskChange = taskChange;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskChange.CreateTaskAsync(request.Name, request.Description,request.ManagerId, cancellationToken);
        }
    }
}
