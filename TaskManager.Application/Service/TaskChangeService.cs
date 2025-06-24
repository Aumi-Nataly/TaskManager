using System.Threading.Tasks;
using System.Xml.Linq;
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

        public async Task<bool> CanBeDoneAsync(int id, CancellationToken cancellationToken)
        {
            await using var ctx = _contextFactory.CreateDbContext();

            IQueryable<TaskRecord> query = ctx.Set<TaskRecord>();
            var taskDB = await query.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (taskDB == null)
                throw new InvalidOperationException($"Task not found {id.ToString()}");

            var taskDomain = TaskMapper.ToDomainChange(taskDB);

             var res = taskDomain.CanBeDone();

            return res;
        }

        public async Task<int> CreateTaskAsync(string name, string description, int ManagerId , CancellationToken cancellationToken)
        {
            await using var ctx = _contextFactory.CreateDbContext();

            var task = new TaskRecord
            {
                Name = name,
                Description = description,
                ManagerId = ManagerId
            };

            var taskDomain = TaskMapper.ToDomainChange(task);
            taskDomain.CreateData();
            TaskMapper.ToDBModelChange(taskDomain, task);

            ctx.TaskRecord.Add(task);
            await ctx.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}
