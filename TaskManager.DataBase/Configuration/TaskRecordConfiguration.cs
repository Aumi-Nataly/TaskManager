

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Database.Records;

namespace TaskManager.Database.Configuration
{
    internal class TaskRecordConfiguration : IEntityTypeConfiguration<TaskRecord>
    {
        public void Configure(EntityTypeBuilder<TaskRecord> builder)
        {
            builder.ToTable("task", Constants.DefaultSchema);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id").IsRequired();
            builder.Property(b => b.Name).IsRequired().HasColumnName("name");
            builder.Property(b => b.Description).HasColumnName("description");
            builder.Property(x => x.Created).HasColumnName("create_date");
            builder.Property(x => x.ManagerId).HasColumnName("manager_id");
            builder.Property(b => b.Status).IsRequired().HasColumnName("status");

            builder.HasOne(x => x.ResponsibleManager).WithMany().HasForeignKey(x => x.ManagerId);
           
        }
    }
}
