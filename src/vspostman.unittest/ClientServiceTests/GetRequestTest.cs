using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VsPostman.HttpRequest;

namespace vspostman.unittest.ClientServiceTests
{
    public partial class ClientServiceTests
    {
        [TestMethod]
        public async Task GetRequestWithoutParametersReturnWithSpecifiedText()
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
            var clientService = new ClientService(factory.Object);
            var actualResponse = await clientService.Get($"http://www.google.com");
            Assert.AreEqual(expected, actualResponse.ResponseString);
        }


        [TestMethod]
        public async Task GetRequestWithNullUrlThrowsArguementNullException()
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
            var clientService = new ClientService(factory.Object);
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async ()=> await clientService.Get(null));
        }

        [TestMethod]
        public async Task GetRequestWithEmptyUrlThrowsArguementNullException()
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
            var clientService = new ClientService(factory.Object);
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await clientService.Get(string.Empty));
        }


        [TestMethod]
        public async Task GetRequestWithParameterNullThrowsArguementNullException()
        {
            // arrange
            var paramKey = "Key";
            var url = "http://www.google.com";

            var expectedBytes = Encoding.UTF8.GetBytes($"{url}?{paramKey}=null");
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
            var clientService = new ClientService(factory.Object);
            clientService.AddParameter(paramKey, null);

            // assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await clientService.Get(null));
        }

        [TestMethod]
        public async Task GetRequestWithSingleParametersReturnUrlAndParamString()
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
            var clientService = new ClientService(factory.Object);
            clientService.AddParameter(paramKey, paramValue);
            var actualResponse = await clientService.Get(url);

            // assert
            Assert.IsTrue(actualResponse.ResponseString.Contains(url));
            Assert.AreEqual($"{url}?{paramKey}={paramValue}", actualResponse.ResponseString);
        }

    }
}
