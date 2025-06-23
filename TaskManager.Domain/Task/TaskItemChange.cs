
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
        public int ResponsibleManagerId { get; set; }
        public TaskStatus Status { get; set; }
        public bool Expired { get; set; }



        public TaskItemChange(int id, string name, string description, DateTime created, int responsibleManagerId, TaskStatus status)
        { 
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is required", nameof(name));

            Id = id;
            Name = name;
            Description = description;
            Created = created;
            ResponsibleManagerId = responsibleManagerId;
            Status = status;
            Expired = created < DateTime.UtcNow.AddDays(-5) ? true : false;

        }

        public bool CanBeDone()
        {
            return Status == TaskStatus.Active && !Expired;
        }

        public void ChangeStatus(TaskStatus status)
        { 
            if (Status == TaskStatus.Done)
                throw new ArgumentNullException("It is forbidden to change the status of completed", nameof(status));

            Status = status;
        }

        public void UpdateData(string name, string description, int responsibleManagerId)
        { 
            if (!string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name is required", nameof(name));

            Description = description;
            ResponsibleManagerId = responsibleManagerId;
        }
    }
}
