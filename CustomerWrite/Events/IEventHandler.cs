using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public interface IEventHandler
    {
        Task ListenForCustomerCreatedEvent(CustomerCreatedEvent createdEvent);
        Task ListenForCustomerUpdatedEvent(CustomerUpdatedEvent updatedEvent);
    }
}
