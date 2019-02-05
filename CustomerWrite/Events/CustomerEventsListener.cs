using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Models;
using CustomerWrite.Repository;

namespace CustomerWrite.Events
{
    public class CustomerEventsListener : IEventHandler
    {
        private ISQLRepository _repo;
        private ServiceBusQueueEvents _eventSender;

        public CustomerEventsListener(ISQLRepository repo)
        {
            _repo = repo;
            _eventSender = new ServiceBusQueueEvents();
        }
        public async Task ListenForCustomerCreatedEvent(CustomerCreatedEvent createdEvent)
        {
            await _repo.AddCustomer(createdEvent.ToCustomerModel());
            await _eventSender.SendEventsToQueue(createdEvent);
            //return createdEvent.ToCustomerModel();
        }

        public async Task ListenForCustomerUpdatedEvent(CustomerUpdatedEvent updatedEvent)
        {
            await _repo.UpdateCustomer(updatedEvent.ToCustomerModel());
            await _eventSender.SendEventsToQueue(updatedEvent);
            //return createdEvent.ToCustomerModel();
        }
    }
}
