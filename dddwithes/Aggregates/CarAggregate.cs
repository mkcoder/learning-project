using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dddwithes.Entities;
using learning.Entity;
using learning.Events;
using learning.Model;
using MediatR;

namespace learning.Aggregates
{
    public class CarAggregate : AggregateRoot, IRequestHandler<RequestCreateCar, CarCreated>, IRequestHandler<ChangeCarManufacture, Car>
    {
        private readonly CarModel _carModel;
        private readonly IMediator _mediator;

        public override Guid Aggregate { get; } = Guid.NewGuid();

        public CarAggregate(CarModel carModel,IMediator mediator)
        {
            _carModel = carModel;
            _mediator = mediator;
        }

        internal List<Car> GetAllCars()
        {
            return _carModel.GetAllCars();
        }

        public async Task<CarCreated> Handle(RequestCreateCar request, CancellationToken cancellationToken)
        {
            var car = await _carModel.CreateNewCarFromEvent(request);
            var carCreated = CarCreated.From(car);
            await _mediator.Publish(AggregateEvent.Create<RequestCreateCar>(car.Id, carCreated, request));
            await _mediator.Publish(carCreated);
            return carCreated;
        }

        public Task<Car> Handle(ChangeCarManufacture request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _carModel.ChangeCarManufacture(request));
        }
    }
}
