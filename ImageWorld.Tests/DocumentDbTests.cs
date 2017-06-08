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
using Microsoft.Azure.Documents.Client;
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
                Id = newGuid,
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

            // change date and update the image
            DocumentDbHelper
                .UpdateImageAsync(imageBack)
                .Wait();

            // can we call out to cognitive services?
            VisionApiHelper
                .AdornImageWithVisionMetadataAsync(imageBack);
            
            // delete the image
            // get the image back
            DocumentDbHelper
                .DeleteImageAsync($"{newGuid}").Wait();
            
        }

        [TestMethod]
        public void CreateImageOnly()
        {
            var newGuid = Guid.NewGuid();

            var image = new Image
            {
                Created = DateTime.Now,
                Description = "Test description",
                Id = newGuid,
                Name = "Test name",
                // use our fluffy test image
                Bytes = File.ReadAllBytes("Images/dog-medium-landing-hero.jpg")
            };

            Console.WriteLine($"{newGuid} written to database!");

        }
        }
}
