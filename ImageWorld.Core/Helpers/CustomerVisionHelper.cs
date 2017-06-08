using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageWorld.Core.Class;
using Microsoft.Cognitive.CustomVision;

namespace ImageWorld.Core.Helpers
{
    public static class CustomerVisionHelper
    {
        public static void RunCustomVisionService(Image image)
        {
            var predictionEndpointCredentials = new PredictionEndpointCredentials(
                Config.Default.CustomVisionPredictionKey
                );

            var endpoint = new PredictionEndpoint(predictionEndpointCredentials);
            

            var result = endpoint.PredictImage(
                new Guid(Config.Default.CustomVisionProjectId),
                new MemoryStream(image.Bytes), 
                new Guid(Config.Default.CustomVisionIterationId));

            var waldo = result
                .Predictions
                .FirstOrDefault(p => p.Tag == "waldo");

            if (waldo != null && waldo.Probability > 0.25d)
            {
                image.WaldoDetected = true;
            }

            image.ProcessedCustomVision = true;
        }
    }
}
