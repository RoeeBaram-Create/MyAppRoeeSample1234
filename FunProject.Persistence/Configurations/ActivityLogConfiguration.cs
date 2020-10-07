using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunProject.Persistence.Configurations
{
    public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
    {
        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder
                .HasOne(al => al.Customer)
                .WithMany(c => c.ActivityLogs)
                .HasForeignKey(al => al.CustomerId);
        }
    }
}
