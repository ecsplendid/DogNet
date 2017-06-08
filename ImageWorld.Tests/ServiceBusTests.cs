using System;
using System.Threading.Tasks;
using ImageWorld.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageWorld.Tests
{
    [TestClass]
    public class ServiceBusTests
    {
        [TestMethod]
        public void PutMessageOnServiceBus() => ServiceBusHelper
                .AddMessageToQueueAsync($"Test message from unit test!")
                .Wait();
    }
}
