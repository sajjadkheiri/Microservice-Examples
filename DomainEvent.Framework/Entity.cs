namespace DomainEvent.Framework;

public class Entity : IEquatable<Entity>
{
    public int Id { get; set; }

    public bool Equals(Entity? other) => this == other;
    
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    private readonly List<IDomainEvent> _domainEvents = new();
    
    protected void AddEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Entity);
    }
}