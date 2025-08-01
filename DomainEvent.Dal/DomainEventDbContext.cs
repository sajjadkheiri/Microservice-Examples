using DomainEvent.Domain.OutBox;
using DomainEvent.Domain.People;
using DomainEvent.Framework;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DomainEvent.Dal;

public class DomainEventDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;

    public DomainEventDbContext(DbContextOptions<DomainEventDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
    {
        _dispatcher = dispatcher;
    }

    public DbSet<Person> People { get; set; }
    public DbSet<OutBox> OutBox { get; set; }


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
        AddToOutBox();
        
        // Config Base Dispatch Events by DbContext
        DispatchEvents();
    }

    private void AddToOutBox()
    {
        var entities = ChangeTracker.Entries<Entity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
            .Select(x => x.Entity)
            .ToList();

        var dateTime = DateTime.Now;
        
        foreach (var entity in entities)
        {
            foreach (var @event in entity.DomainEvents)
            {
                OutBox.Add(new OutBox
                {
                    AccuredByUserId = "1",
                    EventId = Guid.NewGuid(),
                    EventName = @event.GetType().Name,
                    AccuredOn = dateTime,
                    EventPayload = JsonConvert.SerializeObject(@event),
                    IsProcessed = false,
                    AggregateId = "1",
                    AggregateName = entity.GetType().Name,
                    EventTypeName = @event.GetType().FullName,
                    AggregateTypeName = entity.GetType().FullName,
                });
            }
        }
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