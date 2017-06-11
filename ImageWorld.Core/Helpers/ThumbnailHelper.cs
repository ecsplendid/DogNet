using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using ImageWorld.Core.Class;

namespace ImageWorld.Core.Helpers
{
    public static class ThumbnailHelper
    {
        public static async void ApplyThumbnail(Image image)
        {
            var client = new HttpClient();
            
            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", 
                Config.Default.VisionApiKey
                );

            // Request parameters and URI.
            const string RequestParameters = "width=200&height=200&smartCropping=true";
            
            var uri = $"{Config.Default.VisionBaseAddress}/generateThumbnail?" 
                + RequestParameters;

            using (var content = new ByteArrayContent(image.Bytes))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var response = await client.PostAsync(uri, content);

                   image.ThumbnailBytes = await response
                        .Content
                        .ReadAsByteArrayAsync();
            }
        }

      
    }
}
