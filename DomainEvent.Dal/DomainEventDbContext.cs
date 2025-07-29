using DomainEvent.Domain.People;
using Microsoft.EntityFrameworkCore;

namespace DomainEvent.Dal;

public class DomainEventDbContext : DbContext
{
    public DomainEventDbContext(DbContextOptions<DomainEventDbContext>  options) : base(options)
    {
        
    }
    public DbSet<Person> People { get; set; }
    
}