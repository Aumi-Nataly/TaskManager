
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Database.Records
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class TaskRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public int? ManagerId { get; set; }
        public ManagerRecord ResponsibleManager { get; set; }
        public TaskStatus Status { get; set; }
    }
}
