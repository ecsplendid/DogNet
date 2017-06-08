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
                .AddMessageToQueueAsync($"7d66b256-7324-4acf-8d6d-9c394da56686")
                .Wait();
    }
}
