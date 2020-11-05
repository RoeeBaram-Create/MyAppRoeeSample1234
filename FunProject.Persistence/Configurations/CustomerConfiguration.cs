using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunProject.Persistence.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //builder
            //    .HasMany(al => al.ActivityLogs)
            //    .WithOne(c => c.Customer)
            //    .HasForeignKey(al => al.CustomerId);
        }
    }
}
