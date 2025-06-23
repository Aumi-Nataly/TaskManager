

using TaskManager.Database.Records;
using TaskManager.Domain.Task;

namespace TaskManager.Application.Common.Mappers
{
    public static class TaskMapper
    {

        public static TaskItemChange ToDomainChange(TaskRecord taskRecord)
        {
            return new TaskItemChange(taskRecord.Id, taskRecord.Name, taskRecord.Description, taskRecord.Created,
                taskRecord.ResponsibleManager.Id, taskRecord.Status);
        }


        public static void ToDBModelChange(TaskItemChange taskDomain, TaskRecord taskRecord)
        {
            taskRecord.Name = taskDomain.Name;
            taskRecord.Description = taskDomain.Description;
            taskRecord.Created = taskDomain.Created;
            taskRecord.ManagerId = taskDomain.ResponsibleManagerId;
            taskRecord.Status = taskDomain.Status;
        }

    }
}
