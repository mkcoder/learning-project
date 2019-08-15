using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using learning.Entity;
using learning.Events;
using learning.Model;
using MediatR;

namespace learning.Aggregates
{
    public class CarAggregate : AggregateRoot, IRequestHandler<CreateCar, Car>, IRequestHandler<ChangeCarManufacture, Car>
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

        internal Car UpdateManufacture(ChangeCarManufacture car)
        {
            return _carModel.ChangeCarManufacture(car);
        }

        public Task<Car> Handle(CreateCar request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _carModel.CreateNewCarFromEvent(request));
        }

        public Task<Car> Handle(ChangeCarManufacture request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _carModel.ChangeCarManufacture(request));
        }
    }
}
