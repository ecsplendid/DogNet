using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace ImageWorld.Core
{
    public static class ServiceBusHelper
    {

        public static void AddMessageToQueue()
        {
            var EndpointUrl = "https://hsbc-image-database.documents.azure.com:443/";
            var PrimaryKey = "Jvx9ScleKSWy0hQrBp3kGsqKryNoAXmBhfMQIYFzBHzpcHgUNTGGjpEmAhqheizy2v0c2SxIpWmrLYFdlzhb2g==";

            
            
            var client = QueueClient.CreateFromConnectionString(Config.Default.ServiceBusConnectionString);
            //var message = new BrokeredMessage("This is a test message!");
            //client.Send(message);

    }

    }
}
