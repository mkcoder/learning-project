using System.Threading;
using System.Threading.Tasks;
using dddwithes.Entities;
using learning.DbContexts;
using MediatR;

namespace dddwithes.Services
{
    public class EventSourcing : INotificationHandler<AggregateEvent>
    {
        private readonly CarContext _eventSourcingContext;

        public EventSourcing(CarContext eventSourcingContext)
        {
            _eventSourcingContext = eventSourcingContext;
        }

        public async Task Handle(AggregateEvent notification, CancellationToken cancellationToken)
        {
            _eventSourcingContext.AggregateEvents.Add(notification);
            await _eventSourcingContext.SaveChangesAsync();
        }
    }
}
