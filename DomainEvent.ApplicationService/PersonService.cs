using DomainEvent.Dal;
using DomainEvent.Domain.People;
using Microsoft.Extensions.Logging;

namespace DomainEvent.ApplicationService;

public class PersonService(DomainEventDbContext dbContext, ILogger<PersonService> logger)
{
    private readonly DomainEventDbContext _dbContext = dbContext;
    private readonly ILogger<PersonService> _logger = logger;
    
    public async Task CreatePerson(string firstName, string lastName)
    {
        var person = new Person(firstName, lastName);
        
        await _dbContext.People.AddAsync(person);
        await _dbContext.SaveChangesAsync();
        
        foreach (var per in person.DomainEvents)
        {
            _logger.LogInformation($"------- Event is {per.GetType().Name} -------");
        }
    }

    public async Task UpdateFirsName(int id, string firstName)
    {
        var person = _dbContext.People.FirstOrDefault(x => x.Id == id);
        
        if (person == null)
            throw new Exception("Person not found");
        
        person.ChangeFirstName(firstName);
        
        await _dbContext.SaveChangesAsync();
        
        foreach (var per in person.DomainEvents)
        {
            _logger.LogInformation($"------- Event is {per.GetType().Name} -------");
        }
    }
    
    public async Task UpdateLastName(int id, string lastName)
    {
        var person = _dbContext.People.FirstOrDefault(x => x.Id == id);
        
        if (person == null)
            throw new Exception("Person not found");
        
        person.ChangeLastName(lastName);
        
        await _dbContext.SaveChangesAsync();
        
        foreach (var per in person.DomainEvents)
        {
            _logger.LogInformation($"------- Event is {per.GetType().Name} -------");
        }
    }
}