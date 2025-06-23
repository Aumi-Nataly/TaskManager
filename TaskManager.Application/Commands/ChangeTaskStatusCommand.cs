using MediatR;

namespace TaskManager.Application.Commands
{
    public class ChangeTaskStatusCommand: IRequest<Unit>
    {
        public int Id { get; set; }

        public TaskManager.Domain.Task.TaskStatus Status { get; set; }
    }
}
