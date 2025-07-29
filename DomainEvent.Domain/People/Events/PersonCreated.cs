using DomainEvent.Framework;

namespace DomainEvent.Domain.People.Events;

public class PersonCreated(string firstName, string lastName) : IDomainEvent
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}