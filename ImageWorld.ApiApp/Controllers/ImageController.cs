using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ImageWorld.Core.Helpers;
using Swashbuckle.Swagger.Annotations;

namespace ImageWorld.ApiApp.Controllers
{
    public class ImageController : ApiController
    {
     
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage Get(string id)
        {
            var image = DocumentDbHelper
                .GetImageAsync(id)
                .Result;

            if (image == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(image.Bytes)
            };

            result.Content.Headers.ContentType = 
                // bit of an assumption but will suffice for the demo
                new MediaTypeHeaderValue("image/jpg");

            return result;
        }
    }
}
