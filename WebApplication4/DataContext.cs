using Microsoft.EntityFrameworkCore;
using WebApplication4.Entities;

namespace WebApplication4;
public class DataContext: DbContext
{
    private DbSet<Book> Books { get; set; }
    private DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=DbLibrary;Trusted_Connection=True;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}