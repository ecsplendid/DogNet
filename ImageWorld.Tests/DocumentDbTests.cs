using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ImageWorld.Core;
using ImageWorld.Core.Class;
using ImageWorld.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageWorld.Tests
{
    [TestClass]
    public class DocumentDbTests
    {
        /// <summary>
        /// Test creation of an image in docdb, retrieval, updating, deleting
        /// </summary>
        [TestMethod]
        public void TestDocumentDbWrangling()
        {
            var newGuid = Guid.NewGuid();

            var image = new Image
            {
                Created = DateTime.Now,
                Description = "Test description",
                id = newGuid,
                Name = "Test name",
                // use our fluffy test image
                Bytes = File.ReadAllBytes("Images/dog-medium-landing-hero.jpg")
            };

            Console.WriteLine($"{newGuid} written to database!");

            DocumentDbHelper.AddImageToDbAsync(
                image
            ).Wait();

            // get the image back
            var imageBack = DocumentDbHelper
                .GetImageAsync($"{newGuid}")
                .Result;

            imageBack.Created = DateTime.Now;
            imageBack.IllegalWatermark = true;

            // Run the custom vision service
            //CustomerVisionHelper
            //    .RunCustomVisionService(imageBack);
            
            // can we call out to cognitive services?
            VisionApiHelper
                .AdornImageWithVisionMetadataAsync(imageBack);

            // change date and update the image
            DocumentDbHelper
                .UpdateImage(imageBack);

            // delete the image
            // get the image back
            DocumentDbHelper
                .DeleteImageAsync($"{newGuid}").Wait();
        }

        [TestMethod]
        public void CreateImageOnlyWithQueue()
        {
            var newGuid = Guid.NewGuid();

            var image = new Image
            {
                Created = DateTime.Now,
                Description = "Test description",
                id = newGuid,
                Name = "Test name",
                // use our fluffy test image
                Bytes = File.ReadAllBytes("Images/dog-medium-landing-hero.jpg")
            };

            DocumentDbHelper.AddImageToDbAsync(
                image
            ).Wait();

            Console.WriteLine($"{newGuid} written to database!");

            ServiceBusHelper
                .AddMessageToQueueAsync($"{image.id}")
                .Wait();

            Console.WriteLine($"{newGuid} written to service bus!");
        }
    }
}
