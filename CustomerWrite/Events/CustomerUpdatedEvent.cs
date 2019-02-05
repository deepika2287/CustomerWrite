using CustomerWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public class CustomerUpdatedEvent : IEvents
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customers ToCustomerModel()
        {
            return new Customers()
            {
                CustomerId = this.CustomerId,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
