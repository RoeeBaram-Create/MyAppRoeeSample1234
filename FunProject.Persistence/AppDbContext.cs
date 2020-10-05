using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunProject.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }


        // TODO: move to configurations file
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLog>()
                .HasOne(al => al.Customer)
                .WithMany(c => c.ActivityLogs)
                .HasForeignKey(al => al.CustomerId);
        }
    }
}