using System;
using MediatR;

namespace learning.Events
{
    public class RequestChangeCarDescription : IRequest<CarDescriptionChanged>
    {
        public Guid AggregateId { get; set; }
        public string VehicleType { get; set; }
        public int CarDoors { get; set; }
        public string Color { get; set; }
    }
}
