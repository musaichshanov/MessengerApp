using AuthService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> Users {get;set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();
    }
}