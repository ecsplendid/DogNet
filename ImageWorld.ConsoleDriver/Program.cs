using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageWorld.Core.Class;
using ImageWorld.Core.Helpers;

namespace ImageWorld.ConsoleDriver
{
    class Program
    {
        static void Main(string[] args)
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
