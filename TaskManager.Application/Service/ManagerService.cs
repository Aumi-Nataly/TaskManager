using Microsoft.EntityFrameworkCore;
using TaskManager.Database;
using TaskManager.Database.Records;

namespace TaskManager.Application.Service
{
    public class ManagerService : IManager
    {
        private readonly IDbContextFactory<ApplicationDBContext> _contextFactory;

        public ManagerService(IDbContextFactory<ApplicationDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> AddManager(string name, string surname, CancellationToken cancellationToken)
        {
            await using var ctx = _contextFactory.CreateDbContext();
          
            ManagerRecord manager = new ManagerRecord
            {
                Name = name,
                Surname = surname
            };

            ctx.ManagerRecord.Add(manager);

            await ctx.SaveChangesAsync(cancellationToken);

            return manager.Id;
        }
    }
}
