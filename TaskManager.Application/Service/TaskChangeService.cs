using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Mappers;
using TaskManager.Database;
using TaskManager.Database.Records;

namespace TaskManager.Application.Service
{
    public class TaskChangeService: ITaskChange
    {
        private readonly IDbContextFactory<ApplicationDBContext> _contextFactory;
        public TaskChangeService(IDbContextFactory<ApplicationDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task ChangeStatusAsync(int id, TaskManager.Domain.Task.TaskStatus newStatus, CancellationToken cancellationToken)
        {
            await using var ctx = _contextFactory.CreateDbContext();
           
            IQueryable<TaskRecord> query = ctx.Set<TaskRecord>();

            var taskDB = await query.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (taskDB == null)
                throw new InvalidOperationException($"Task not found {id.ToString()}");

            var taskDomain = TaskMapper.ToDomainChange(taskDB);
            taskDomain.ChangeStatus(newStatus);
            TaskMapper.ToDBModelChange(taskDomain, taskDB);

            await ctx.SaveChangesAsync(cancellationToken);
        }
    }
}
