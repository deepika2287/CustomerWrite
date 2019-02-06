using CustomerWrite.Events;
using CustomerWrite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Commands
{
    public class CustomerCommandHandler : ICommandHandler
    {
        private ISQLRepository _repo;
        private IEventHandler _myEvent;

        public CustomerCommandHandler(ISQLRepository repo, IEventHandler myEvent)
        {
            _repo = repo;
            _myEvent = myEvent;
        }

        public async Task ListenForCustomerCreatedCommand(CreateCustomerCommand createCustomer)
        {
            var eventObj = createCustomer.ToCustomerCreatedEvent();
            await _myEvent.ListenForCustomerCreatedEvent(eventObj);
            //throw new NotImplementedException();
        }
    }
}
