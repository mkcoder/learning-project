using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dddwithes.Entities;
using learning.DbContexts;
using learning.DomainObjects;
using Microsoft.AspNetCore.Mvc;

namespace dddwithes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
	{
        public EventsController(CarContext carContext)
        {
            CarContext = carContext;
        }

        public CarContext CarContext { get; }

        [HttpGet]
        public List<AggregateEvent> GetEvents()
        {
            return CarContext.AggregateEvents.ToList();
        }

        [HttpGet("{id}")]
        public List<AggregateEvent> GetEvents(Guid id)
        {
            return CarContext.AggregateEvents.Where(e => e.AggregateId == id).ToList();
        }
    }
}
