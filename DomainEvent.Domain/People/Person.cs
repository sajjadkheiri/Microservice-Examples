using DomainEvent.Domain.People.Events;
using DomainEvent.Framework;

namespace DomainEvent.Domain.People;

public class Person : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Person(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new Exception("First name cannot be null or empty");
        if (string.IsNullOrEmpty(lastName))
            throw new Exception("Last name cannot be null or empty");

        FirstName = firstName;
        LastName = lastName;
        
        AddEvent(new PersonCreated(FirstName, LastName));
    }

    public void ChangeFirstName(string newFirstName)
    {
        if (string.IsNullOrEmpty(newFirstName))
            throw new Exception("First name cannot be null or empty");

        FirstName = newFirstName;
        
        AddEvent(new FirstNameChanged(Id,FirstName));
    }

    public void ChangeLastName(string newLastName)
    {
        if (string.IsNullOrEmpty(newLastName))
            throw new Exception("Last name cannot be null or empty");

        LastName = newLastName;

        AddEvent(new LastNameChanged(Id,LastName));
    }
}