using Microservice.ValueObject.EF.Model.ValueObjects;

namespace Microservice.ValueObject.EF.Model;

public class Person
{
    public Person(int id, FirstName firstName, LastName lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    private Person()
    {
        
    }

    public int Id { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
}