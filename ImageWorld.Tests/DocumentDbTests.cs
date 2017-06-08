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
        /// see 
        /// https://stackoverflow.com/questions/858761/what-causing-this-invalid-length-for-a-base-64-char-array
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void PutImageInDocumentDb()
        {
            var newGuid = Guid.NewGuid();

            var image = new Image
            {
                Description = "Test description",
                Id = newGuid,
                Name = "Test name",
                // use our fluffy test image
                Bytes = File.ReadAllBytes("Images/dog-medium-landing-hero.jpg")
            };

            DocumentDbHelper.AddImageToDbAsync(
                image
            ).Wait();
        }
    }
}
