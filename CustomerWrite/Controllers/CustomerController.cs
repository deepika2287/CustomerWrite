using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Events;
using CustomerWrite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IEventHandler _myEvents;
        public CustomerController(IEventHandler myEvents)
        {
            _myEvents = myEvents;
        }
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Customers>> Post([FromBody] Customers value)
        {
            CustomerCreatedEvent customerCreated = new CustomerCreatedEvent();
            customerCreated.CustomerId = value.CustomerId;
            customerCreated.FirstName = value.FirstName;
            customerCreated.LastName = value.LastName;

            await _myEvents.ListenForCustomerCreatedEvent(customerCreated);
            return Ok();

        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<Customers>> Put([FromBody] Customers value)
        {
            CustomerUpdatedEvent custUpdated = new CustomerUpdatedEvent();
            custUpdated.CustomerId = value.CustomerId;
            custUpdated.FirstName = value.FirstName;
            custUpdated.LastName = value.LastName;

            await _myEvents.ListenForCustomerUpdatedEvent(custUpdated);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
