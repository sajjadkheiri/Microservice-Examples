using DomainEvent.Framework;

namespace DomainEvent.Domain.People.Events;

public class LastNameChanged(int id, string lastName) : IDomainEvent
{
    public int Id { get; set; } = id;
    public string LastName { get; set; } = lastName;
}