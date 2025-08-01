using DomainEvent.Dal;
using DomainEvent.Framework;

namespace DomainEvent.ApplicationService.Person;

public class PersonService(DomainEventDbContext dbContext,IDomainEventDispatcher domainEventDispatcher)
{
    private readonly DomainEventDbContext _dbContext = dbContext;
    private readonly IDomainEventDispatcher _domainEventDispatcher = domainEventDispatcher;

    public async Task CreatePerson(string firstName, string lastName)
    {
        var person = new Domain.People.Person(firstName, lastName);

        await _dbContext.People.AddAsync(person);
        
        // Config Base Dispatch Events by writing framework
        await _domainEventDispatcher.DispatchEventsAsync(person.DomainEvents);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateFirsName(int id, string firstName)
    {
        var person = _dbContext.People.FirstOrDefault(x => x.Id == id);

        if (person == null)
            throw new Exception("Person not found");

        person.ChangeFirstName(firstName);

        // Config Base Dispatch Events by writing framework
        await _domainEventDispatcher.DispatchEventsAsync(person.DomainEvents);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateLastName(int id, string lastName)
    {
        var person = _dbContext.People.FirstOrDefault(x => x.Id == id);

        if (person == null)
            throw new Exception("Person not found");

        person.ChangeLastName(lastName);

        // Config Base Dispatch Events by writing framework
        await _domainEventDispatcher.DispatchEventsAsync(person.DomainEvents);
        
        await _dbContext.SaveChangesAsync();
    }
}