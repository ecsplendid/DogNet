using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;

namespace ImageWorld.Functions
{
    public static class ProcessImage
    {
        [FunctionName("ServiceBusQueueTriggerCSharp")]                    
        public static void Run(
            [ServiceBusTrigger("images", AccessRights.Manage, Connection = "ServiceBusConnection")]
            string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}