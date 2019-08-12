using System;
using System.Collections.Generic;
using learning.Entity;
using learning.Events;
using learning.Model;

namespace learning.Aggregates
{
    public class CarAggregate : AggregateRoot
    {
        private readonly CarModel _carModel;

        public override Guid Aggregate { get; } = Guid.NewGuid();

        public CarAggregate(CarModel carModel)
        {
            _carModel = carModel;
        }

        public Car CreateCar(CreateCar carEvent)
        {
            return _carModel.CreateNewCarFromEvent(carEvent);
        }

        internal List<Car> GetAllCars()
        {
            return _carModel.GetAllCars();
        }
    }
}
