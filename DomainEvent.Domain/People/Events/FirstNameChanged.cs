using DomainEvent.Framework;

namespace DomainEvent.Domain.People.Events;

public class FirstNameChanged(int id, string firstName) : IDomainEvent
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
}