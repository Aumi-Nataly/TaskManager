
namespace TaskManager.Application.Service
{
    public interface ITaskChange
    {
        Task ChangeStatusAsync(int id, TaskManager.Domain.Task.TaskStatus newStatus, CancellationToken cancellationToken);

        Task<bool> CanBeDoneAsync(int id, CancellationToken cancellationToken);

        Task<int> CreateTaskAsync(string name, string description, int ManagerId, CancellationToken cancellationToken);
    }
}
