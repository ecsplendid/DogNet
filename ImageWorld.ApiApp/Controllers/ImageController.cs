using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ImageWorld.Core.Class;
using ImageWorld.Core.Helpers;
using Swashbuckle.Swagger.Annotations;

namespace ImageWorld.ApiApp.Controllers
{
    public class ImageController : ApiController
    {
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<HttpResponseMessage> GetById(string id)
        {
            var image = await DocumentDbHelper
                .GetImageAsync(id);

            if (image == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(
                    image.Bytes
                )
            };
            
            result.Headers.CacheControl = new CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromMinutes(30)
                }; ;

            result.Content.Headers.ContentType = 
                // bit of an assumption but will suffice for the demo
                new MediaTypeHeaderValue("image/jpg");

            return result;
        }
        
        [SwaggerOperation("GetImages")]
        [Route("api/Image/GetImages")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> GetImages()
        {

            var images = DocumentDbHelper
                .GetAllImageIds()
                .Select(async ev => await DocumentDbHelper.GetImageAsync(ev))
                .ToArray();

            await Task.WhenAll(tasks: images);

            var i2 = images
                .Select(t => t.Result)
                .Where(i => !string.IsNullOrWhiteSpace(i.PredictedCaption));

            // null off the binary data for all images

            foreach (var image in i2)
            {
                image.Bytes = null;
            }
            


            return Ok(i2);
        }

        [Route("api/Image/upload")]
        [HttpPost]
        [AcceptVerbs("POST")]
        public async Task UploadSingleFile()
        {
            var bytes = await Request
                .Content
                .ReadAsByteArrayAsync();

            var guid = Guid.NewGuid();

            await DocumentDbHelper.AddImageToDbAsync(new Core.Class.Image
            {
                id = guid,
                Bytes = bytes
            });

            await ServiceBusHelper
                        .AddMessageToQueueAsync(guid.ToString()
                );
        }
    }
}
