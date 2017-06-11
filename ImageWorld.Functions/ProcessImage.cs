using System.IO;
using ImageWorld.Core.Helpers;
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
            string imageId, TraceWriter log)
        {
            
            log.Info($"New image detected from the queue: {imageId}");

            var image = DocumentDbHelper
                .GetImageAsync($"{imageId}").Result;

            // if we can't find it in the database, do nothing
            if (image == null)
            {
                log.Info($"This image wasn't found in the database.");
                return;
            }

            VisionApiHelper
                .AdornImageWithVisionMetadataAsync(
                    image
                    );

            CustomerVisionHelper
                .RunCustomVisionService(image);

            // insert azureML code here

            ThumbnailHelper
                .ApplyThumbnail(image);

            DocumentDbHelper
                .UpdateImage(image);

            if (image.Tags == null) return;

            log.Info($"Adorned image tags to it from cognitive services ({string.Join(",", image.Tags)})");
            log.Info($"And this description: ({image.PredictedCaption})");
        }
    }
}