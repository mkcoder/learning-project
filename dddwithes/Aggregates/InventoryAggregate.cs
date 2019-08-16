using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dddwithes.Entities;
using learning.DbContexts;
using learning.Events;
using MediatR;
using testing.Controllers;

namespace dddwithes.Aggregates
{
    public class InventoryAggregate :
        INotificationHandler<CarCreated>,
        IRequestHandler<RequestAddCarToInventory, CarAddedToInventory>,
        IRequestHandler<GetAllInvetory, IEnumerable<Inventory>>
    {
        private readonly IMediator mediator;
        private readonly CarContext context;

        public InventoryAggregate(IMediator mediator, CarContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        public async Task<IEnumerable<Inventory>> Handle(GetAllInvetory request, CancellationToken cancellationToken)
            => context.Inventory.ToList();

        public async Task Handle(CarCreated notification, CancellationToken cancellationToken)
            => await mediator.Send(RequestAddCarToInventory.From(notification));

        public async Task<CarAddedToInventory> Handle(RequestAddCarToInventory request, CancellationToken cancellationToken)
        {
            var ivt = new Inventory
            {
                Id = request.AggregateId,
                CarId = request.CarId,
                Lot = request.Lot,
                Quantity = request.Quanity
            };
            context.Inventory.Add(ivt);
            await context.SaveChangesAsync();
            var evt = CarAddedToInventory.From(ivt);
            await mediator.Publish(AggregateEvent.Create<RequestAddCarToInventory>(request.AggregateId, evt, request));
            await mediator.Publish(evt);
            return evt;
        }

    }
}
