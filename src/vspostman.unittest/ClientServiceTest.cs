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
        public void AddParameters_SingleParameter()
        {
            var key = "testKey";
            var value = "testValue";
            var clientService = new ClientService();
            clientService.AddParameter(key, value);
            Assert.IsFalse(string.IsNullOrEmpty(clientService.ParameterString));
            Assert.AreEqual($"{key}={value}", clientService.ParameterString);
        }

        [TestMethod]
        public void AddParameters_MultipleParameter()
        {
            var key1 = "testKey1";
            var value1 = "testValue1";
            var key2 = "testKey2";
            var value2 = "testValue2";
            var clientService = new ClientService();
            clientService.AddParameter(key1, value1);
            clientService.AddParameter(key2, value2);
            Assert.IsFalse(string.IsNullOrEmpty(clientService.ParameterString));
            Assert.AreEqual($"{key1}={value1}&{key2}={value2}", clientService.ParameterString);
        }

        [TestMethod]
        public void ClearParameters_Test()
        {
            var key = "testKey";
            var value = "testValue";
            var clientService = new ClientService();
            clientService.AddParameter(key, value);
            Assert.IsFalse(string.IsNullOrEmpty(clientService.ParameterString));
            Assert.AreEqual($"{key}={value}", clientService.ParameterString);
            clientService.ClearParameters();
            Assert.IsTrue(string.IsNullOrEmpty(clientService.ParameterString));
        }


    }
}
