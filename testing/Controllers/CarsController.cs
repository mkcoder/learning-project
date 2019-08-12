using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning.Aggregates;
using learning.DomainObjects;
using learning.Entity;
using learning.Events;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace learning.AggregateController
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarAggregate _carAggregate;

        public CarsController(CarAggregate carAggregate)
        {
            _carAggregate = carAggregate;
        }

        [HttpGet]
        public List<Car> GetAllCars() => _carAggregate.GetAllCars();

        [HttpPost]
        public Entity.Car CreateCar([FromBody]CreateCar car)
        {
            return _carAggregate.CreateCar(car);
        }

    }
}
