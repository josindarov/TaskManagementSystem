using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain.Models.Tasks;

namespace TaskManagementSystem.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tasks>()
            .HasNoKey();
        
        base.OnModelCreating(modelBuilder);
    }
}