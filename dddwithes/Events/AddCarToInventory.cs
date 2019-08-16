using System;
using dddwithes.Entities;
using learning.DomainObjects;
using MediatR;

namespace learning.Events
{
    public class RequestAddCarToInventory : IRequest<CarAddedToInventory>
    {
        public Guid AggregateId { get; set; }
        public Guid CarId { get; set; }
        public int Quanity { get; set; } = 10;
        public int Lot { get; set; } = 0;

        internal static RequestAddCarToInventory From(CarCreated evt)
        {
            return new RequestAddCarToInventory
            {
                AggregateId = evt.EventId,
                CarId = evt.AggregateId,
            };
        }
    }

    public class CarAddedToInventory : Event, INotification
    {
        public override string EventName => "CarAddedToInventory";
        public Guid AggregateId { get; set; }
        public Guid CarId { get; set; }
        public int Quanity { get; set; } = 10;
        public int Lot { get; set; } = 0;

        internal static CarAddedToInventory From(Inventory ivt)
        {
            return new CarAddedToInventory
            {
                AggregateId = ivt.Id,
                CarId = ivt.CarId,
                Quanity = ivt.Quantity,
                Lot = ivt.Lot
            };
        }
    }
}