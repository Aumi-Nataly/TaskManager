
namespace TaskManager.Application.Service
{
    public interface ITaskChange
    {
        Task ChangeStatusAsync(int id, TaskManager.Domain.Task.TaskStatus newStatus, CancellationToken cancellationToken);
    }
}
