using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageWorld.Core.Class;
using ImageWorld.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageWorld.Tests
{
    [TestClass]
    public class CustomVisionTests
    {
        [TestMethod]
        public void TestCustomVision()
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

            CustomerVisionHelper.RunCustomVisionService(image);
        }
    }
}
