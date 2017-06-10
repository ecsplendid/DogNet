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
                Content = new ByteArrayContent(image.Bytes)
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
        public IHttpActionResult GetImages()
        {
            var image = DocumentDbHelper
                .GetAllImageIds()
                .Select( s => $"http://hsbc-api-app.azurewebsites.net/api/Image/GetById/?id={s}" );
            
            return Ok(image);
        }

        [Route("api/Image/upload")]
        [HttpPost]
        [AcceptVerbs("POST")]
        public async void UploadSingleFile([FromBody] HttpPostedFileBase uploadFile)
        { 
            using (var ms = new MemoryStream())
            {
                uploadFile.InputStream.CopyTo(ms);

                var bytes = ms.ToArray();

                await DocumentDbHelper.AddImageToDbAsync(new Core.Class.Image
                {
                    id = Guid.NewGuid(),
                    Bytes = bytes
                });
            }

        }

    }
}
