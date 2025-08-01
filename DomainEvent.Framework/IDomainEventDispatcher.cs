using Microsoft.Extensions.DependencyInjection;

namespace DomainEvent.Framework;

public interface IDomainEventDispatcher
{
    Task DispatchEventsAsync(IEnumerable<IDomainEvent> domainEvent);
}

public class DomainEventDispatcher :  IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public Task DispatchEventsAsync(IEnumerable<IDomainEvent> domainEvent)
    {
        foreach (dynamic @event in domainEvent)
        {
            DispatchEvent(@event);
        }   
        
        return Task.CompletedTask;
    }

    private Task DispatchEvent<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
    {
        var handlers = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();

        foreach (var handler in handlers)
        {
            handler.Handle(domainEvent);
        }
        
        return Task.CompletedTask;
    }
} 