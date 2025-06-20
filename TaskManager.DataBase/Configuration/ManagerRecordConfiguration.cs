
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Database.Records;

namespace TaskManager.Database.Configuration
{
    internal class ManagerRecordConfiguration : IEntityTypeConfiguration<ManagerRecord>
    {
        public void Configure(EntityTypeBuilder<ManagerRecord> builder)
        {
            builder.ToTable("manager", Constants.DefaultSchema);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id").IsRequired();
            builder.Property(b => b.Name).IsRequired().HasColumnName("name");
            builder.Property(b => b.Surname).IsRequired().HasColumnName("surname");
        }
    }
}
