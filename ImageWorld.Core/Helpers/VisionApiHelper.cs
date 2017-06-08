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
        public static async void AdornImageWithVisionMetadataAsync(Image image)
        {
            var visionClient = new VisionServiceClient(
                "7713f8479f4941d6a42ff988ceff2b28",
                "https://southeastasia.api.cognitive.microsoft.com/vision/v1.0"
                );

            var visualFeatures = new []
            {
                VisualFeature.Tags
            };
            
            var analysisResult = 
                await visionClient.AnalyzeImageAsync(
                    new MemoryStream(image.Bytes), visualFeatures
                    );

            image.Tags = analysisResult
                .Tags
                .Select( t => t.Name )
                .ToArray();

            DocumentDbHelper
                .UpdateImageAsync(image)
                .Wait();
        }

    }
}
