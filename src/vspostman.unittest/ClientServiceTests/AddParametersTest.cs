using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VsPostman.HttpRequest;

namespace vspostman.unittest.ClientServiceTests
{


    [TestClass]
    public partial class ClientServiceTests
    {
        Mock<IRequest> _mock = new Mock<IRequest>();


        [TestMethod]
        [TestCategory("Parameter Validation - Get Request")]
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
        [TestCategory("Parameter Validation - Get Request")]
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
        [TestCategory("Parameter Validation - Get Request")]
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
