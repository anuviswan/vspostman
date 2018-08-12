using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        [TestMethod]
        public async Task SimpleGetRequest()
        {
            // arrange
            var expected = "response content";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);

            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseAsync()).Returns(Task.FromResult<WebResponse>(response.Object));

            var factory = new Mock<IHttpWebRequestFactory>();
            factory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(request.Object);

            // act
            var clientService = new ClientService(factory.Object)
            {
                Url = "http://www.google.com"
            };
            var actualRequest = await clientService.Get();
            Assert.AreEqual(expected, actualRequest);
        }

        [TestMethod]
        public async Task GetRequestWithParameters()
        {

            // arrange
            var paramKey = "Key";
            var paramValue = "Value";
            var url = "http://www.google.com";
            
            var expectedBytes = Encoding.UTF8.GetBytes($"{url}?{paramKey}={paramValue}");
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);

            var request = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseAsync()).Returns(Task.FromResult<WebResponse>(response.Object));

            var factory = new Mock<IHttpWebRequestFactory>();
            factory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(request.Object);

            // act
            var clientService = new ClientService(factory.Object)
            {
                Url = url
            };
            clientService.AddParameter(paramKey, paramValue);
            var actualRequest = await clientService.Get();
            Assert.IsTrue(actualRequest.Contains(url));
            Assert.AreEqual($"{url}?{paramKey}={paramValue}",actualRequest);
        }

    }
}
