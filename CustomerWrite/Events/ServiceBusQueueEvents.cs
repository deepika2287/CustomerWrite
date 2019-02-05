using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerWrite.Models;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace CustomerWrite.Events
{
    public class ServiceBusQueueEvents
    {
        public async Task SendEventsToQueue(IEvents custEvents)
        {
            string connectionstring = "Endpoint=sb://customerdomaindemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=WFM8dOz9CuMbGJygUVlL/Vqtwas35uhEPQ4K6t5s2Rk=";
            QueueClient client = new QueueClient(connectionstring, "customercreatedqueue");
            Message msg = new Message();
            
            var jsonData = JsonConvert.SerializeObject(custEvents);

            var byteData = Encoding.ASCII.GetBytes(jsonData);
            msg.Body = byteData;
            await client.SendAsync(msg);           
        }
    }
}
