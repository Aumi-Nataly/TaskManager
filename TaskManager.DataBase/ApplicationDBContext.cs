
using Microsoft.EntityFrameworkCore;
using TaskManager.Database.Records;

namespace TaskManager.Database
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<ManagerRecord> ManagerRecord { get; set; }
        public DbSet<TaskRecord> TaskRecord { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

    }
}
