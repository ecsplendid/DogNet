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
            string guid, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {guid}");

            // 7d66b256-7324-4acf-8d6d-9c394da56686

            // get the image from docdb

            // send it to cognitive services

            // adorn the metadata to the doc

            // send it back into docdb



        }
    }
}