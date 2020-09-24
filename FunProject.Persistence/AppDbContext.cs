using FunProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunProject.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        { }
        
        public DbSet<Customer> Customers { get; set; }
    }
}