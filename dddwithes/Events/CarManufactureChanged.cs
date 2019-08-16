using System;
using learning.DomainObjects;
using learning.Entity;
using MediatR;

namespace learning.Events
{
    public class CarManufactureChanged : Event, INotification
    {
        public Guid AggregateId { get; set; }
        public override int Version { get => 1; }
        public override string EventName { get => "CarManufactureChanged"; }
        public string CarDoorsWheelType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }

        public static CarManufactureChanged From(Car car)
        {
            return new CarManufactureChanged
            {
                AggregateId = car.Id,
                CarDoorsWheelType = car.CarDoorsWheelType,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year
            };
        }
    }
}
