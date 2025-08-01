using DomainEvent.Domain.People;
using DomainEvent.Framework;
using Microsoft.EntityFrameworkCore;

namespace DomainEvent.Dal;

public class DomainEventDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;
    public DomainEventDbContext(DbContextOptions<DomainEventDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Person> People { get; set; }


    public override int SaveChanges()
    {
        HandleBeforeSaveChange();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        HandleBeforeSaveChange();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        HandleBeforeSaveChange();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        HandleBeforeSaveChange();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void HandleBeforeSaveChange()
    {
        // Config Base Dispatch Events by DbContext
        DispatchEvents();
    }

    private void DispatchEvents()
    {
        var entities = ChangeTracker.Entries<Entity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .Select(x => x.Entity)
            .ToList();

        foreach (var entity in entities)
        {
            _dispatcher.DispatchEventsAsync(entity.DomainEvents);
            entity.ClearEvents();
        }
    }
}