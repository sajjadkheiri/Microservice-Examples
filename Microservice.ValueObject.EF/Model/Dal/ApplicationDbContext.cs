using Microservice.ValueObject.EF.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Microservice.ValueObject.EF.Model.Dal;

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().OwnsOne(x => x.FirstName);
        modelBuilder.Entity<Person>().Property(x => x.LastName).HasConversion(x => x.Value, x => new LastName(x));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial catalog=ValueObjectDB;User=sa;Password=S@jj@d0910;TrustServerCertificate=True");
    }
}