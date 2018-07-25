using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using vspostman;
using VsPostman.HttpRequest;

namespace vspostman.unittest
{
    [TestClass]
    public class ClientServiceTest
    {
        Mock<IRequest> _mock = new Mock<IRequest>();
        [TestMethod]
        public void AddParameters_Test()
        {
            var key = "testKey";
            var value = "testValue";
            var clientService = new ClientService();
            clientService.AddParameter(key, value);
            Assert.IsFalse(string.IsNullOrEmpty(clientService.ParameterString));
            Assert.AreEqual($"{key}={value}", clientService.ParameterString);
        }

        
    }
}
