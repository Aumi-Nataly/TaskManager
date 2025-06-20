

namespace TaskManager.Domain.Task
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class TaskItemChange : ITaskItemChange
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ResponsibleManager { get; set; }
        public TaskStatus Status { get; set; }
        public bool Expired { get; set; }



        public TaskItemChange(int id, string name, string description, DateTime created, string responsibleManager, TaskStatus status)
        { 
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is required", nameof(name));

            Id = id;
            Name = name;
            Description = description;
            Created = created;
            ResponsibleManager = responsibleManager;
            Status = status;
            Expired = created < DateTime.UtcNow.AddDays(-5) ? true : false;

        }

        public bool CanBeDone()
        {
            return Status == TaskStatus.Active && !Expired;
        }
    }
}
