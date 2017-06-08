using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace ImageWorld.Core.Helpers
{
    public static class ServiceBusHelper
    {
        public static async Task AddMessageToQueueAsync(string message)
        {
            var client = QueueClient.CreateFromConnectionString(
                Config.Default.ServiceBusConnectionString
                );
            
            await client.SendAsync(new BrokeredMessage(message));
        }
    }
}
