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
    public class CarAggregate : AggregateRoot,
        IRequestHandler<RequestCreateCar, CarCreated>,
        IRequestHandler<RequestChangeCarManufacture, CarManufactureChanged>,
        IRequestHandler<RequestChangeCarDescription, CarDescriptionChanged>
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

        public async Task<CarManufactureChanged> Handle(RequestChangeCarManufacture request, CancellationToken cancellationToken)
        {
            var result = await _carModel.ChangeCarManufacture(request);
            var evt = CarManufactureChanged.From(result);
            await _mediator.Publish(AggregateEvent.Create<RequestChangeCarManufacture>(evt.AggregateId, evt, request));
            await _mediator.Publish(evt);
            return evt;
        }

        public Task<CarDescriptionChanged> Handle(RequestChangeCarDescription request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
