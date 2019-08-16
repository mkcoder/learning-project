using System;
using MediatR;

namespace learning.Events
{
    public class RequestChangeCarManufacture : IRequest<CarManufactureChanged>
    {
        public Guid AggregateId { get; set; }
        public string CarDoorsWheelType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
    }
}
