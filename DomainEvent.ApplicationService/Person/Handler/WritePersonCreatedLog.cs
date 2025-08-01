using DomainEvent.Domain.People.Events;
using DomainEvent.Framework;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DomainEvent.ApplicationService.Person.Handler;

public class WritePersonCreatedLog(ILogger<WritePersonCreatedLog> logger) : IDomainEventHandler<PersonCreated>
{
    public Task Handle(PersonCreated @event)
    {
        var data = JsonConvert.SerializeObject(@event);
        logger.LogInformation(data);
        
        return Task.CompletedTask;
    }
}