using System;
using learning.DomainObjects;
using MediatR;

namespace learning.Events
{
    public class CarDescriptionChanged : Event, INotification
    {
        public Guid AggregateId { get; set; }
        public override int Version { get => 1; }
        public override string EventName { get => "CarDescriptionChanged"; }
        public string VehicleType { get; set; }
        public int CarDoors { get; set; }
        public string Color { get; set; }
    }
}
