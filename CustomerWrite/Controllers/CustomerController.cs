using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Events;
using CustomerWrite.Models;
using Microsoft.AspNetCore.Mvc;
using CustomerWrite.Commands;

namespace CustomerWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICommandHandler _myCommands;
        public CustomerController(ICommandHandler myEvents)
        {
            _myCommands = myEvents;
        }
        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Customers>> Post([FromBody] Customers value)
        {

            CreateCustomerCommand customerCreated = new CreateCustomerCommand();
            customerCreated.CustomerId = value.CustomerId;
            customerCreated.FirstName = value.FirstName;
            customerCreated.LastName = value.LastName;

            await _myCommands.ListenForCustomerCreatedCommand(customerCreated);
            return Ok();

        }

        // PUT api/values/5
        [HttpPut]
        public  void Put([FromBody] Customers value)
        {
            //CustomerUpdatedEvent custUpdated = new CustomerUpdatedEvent();
            //custUpdated.CustomerId = value.CustomerId;
            //custUpdated.FirstName = value.FirstName;
            //custUpdated.LastName = value.LastName;

            //await _myCommands.ListenForCustomerUpdatedEvent(custUpdated);

            //return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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

    }
}
