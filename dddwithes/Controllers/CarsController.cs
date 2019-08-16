using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning.Aggregates;
using learning.DomainObjects;
using learning.Entity;
using learning.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace learning.AggregateController
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarAggregate _carAggregate;
        private readonly IMediator _mediator;

        public CarsController(CarAggregate carAggregate, IMediator mediator)
        {
            _carAggregate = carAggregate;
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult GetAllCars() => Ok(_carAggregate.GetAllCars());

        [HttpPost]
        public async Task<ActionResult> CreateCarAsync([FromBody]RequestCreateCar car)
        {
            try
            {
                await _mediator.Send(car);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCarAsync([FromBody]RequestChangeCarManufacture car)
        {
            try
            {
                await _mediator.Send(car);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
