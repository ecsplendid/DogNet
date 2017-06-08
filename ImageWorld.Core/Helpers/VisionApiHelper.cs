using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageWorld.Core.Class;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;

namespace ImageWorld.Core.Helpers
{
    public class VisionApiHelper
    {
        /// <summary>
        /// Goto cognitive services and get the image metadata
        /// </summary>
        public static void AdornImageWithVisionMetadataAsync(Image image)
        {
            var visionClient = new VisionServiceClient(
                Config.Default.VisionApiKey,
                Config.Default.VisionBaseAddress
                );

            var visualFeatures = new []
            {
                VisualFeature.Tags, VisualFeature.Description
            }; 
            
            var analysisResult = 
                visionClient.AnalyzeImageAsync(
                    new MemoryStream(image.Bytes), visualFeatures
                    ).Result;

            if (analysisResult.Tags != null
                && analysisResult.Tags.Any())
            {
                image.Tags = analysisResult
                    .Tags
                    .Select(t => t.Name)
                    .ToArray();
            }

            var firstOrDefault = analysisResult
                .Description
                .Captions
                .FirstOrDefault();

            // add in the image caption
            if (firstOrDefault != null)
                image.PredictedCaption = firstOrDefault.Text;

            image.ProcessedCognitiveServices = true;
        }
    }
}
