using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Events;

namespace CustomerWrite.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerCreatedEvent ToCustomerCreatedEvent()
        {
            return new CustomerCreatedEvent()
            {
                CustomerId = this.CustomerId,
                FirstName = this.FirstName,
                LastName = this.LastName
            };

        }
    }
}
