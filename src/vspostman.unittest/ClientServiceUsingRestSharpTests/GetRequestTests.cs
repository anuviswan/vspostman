using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VsPostman.HttpRequest;

namespace vspostman.unittest.ClientServiceUsingRestSharpTests
{
    [TestClass]
    public class GetRequestUsingRestSharpTests
    {
        [TestMethod]
        public async Task GetRequestWithoutParametersReturnWithSpecifiedText()
        {
            // arrange
            var expected = "response content";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient
              .Setup(x => x.ExecuteAsync(
                  It.IsAny<IRestRequest>(),
                  It.IsAny<Action<IRestResponse, RestRequestAsyncHandle>>()))
              .Callback<IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>>((request, callback) =>
              {
                  callback(new RestResponse { StatusCode = HttpStatusCode.OK }, null);
              });


            // act
            var clientService = new ClientServiceUsingRestSharp(restClient.Object);
            var actualResponse = await clientService.Get($"http://www.google.com");

            //assert
            Assert.AreEqual(expected, actualResponse.ResponseString);
        }


        [TestMethod]
        public async Task GetRequestWithNullUrlThrowsArguementNullException()
        {
            // arrange
            var expected = "response content";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient
              .Setup(x => x.ExecuteAsync(
                  It.IsAny<IRestRequest>(),
                  It.IsAny<Action<IRestResponse, RestRequestAsyncHandle>>()))
              .Callback<IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>>((request, callback) =>
              {
                  callback(new RestResponse { StatusCode = HttpStatusCode.OK }, null);
              });

            // act
            var clientService = new ClientServiceUsingRestSharp(restClient.Object);
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await clientService.Get(null));
        }

        [TestMethod]
        public async Task GetRequestWithEmptyUrlThrowsArguementNullException()
        {
            // arrange
            var expected = "response content";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient
              .Setup(x => x.ExecuteAsync(
                  It.IsAny<IRestRequest>(),
                  It.IsAny<Action<IRestResponse, RestRequestAsyncHandle>>()))
              .Callback<IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>>((request, callback) =>
              {
                  callback(new RestResponse { StatusCode = HttpStatusCode.OK }, null);
              });

            // act
            var clientService = new ClientServiceUsingRestSharp(restClient.Object);
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await clientService.Get(string.Empty));
        }


        [TestMethod]
        public async Task GetRequestWithParameterNullThrowsArguementNullException()
        {
            // arrange
            var paramKey = "Key";
            var url = "http://www.google.com";

            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient
              .Setup(x => x.ExecuteAsync(
                  It.IsAny<IRestRequest>(),
                  It.IsAny<Action<IRestResponse, RestRequestAsyncHandle>>()))
              .Callback<IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>>((request, callback) =>
              {
                  callback(new RestResponse { StatusCode = HttpStatusCode.OK }, null);
              });

            // act
            var clientService = new ClientServiceUsingRestSharp(restClient.Object);
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

            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient
              .Setup(x => x.ExecuteAsync(
                  It.IsAny<IRestRequest>(),
                  It.IsAny<Action<IRestResponse, RestRequestAsyncHandle>>()))
              .Callback<IRestRequest, Action<IRestResponse, RestRequestAsyncHandle>>((request, callback) =>
              {
                  callback(new RestResponse { StatusCode = HttpStatusCode.OK, Content = $"{url}?{paramKey}={paramValue}" }, null);
              });

            // act
            var clientService = new ClientServiceUsingRestSharp(restClient.Object);
            clientService.AddParameter(paramKey, paramValue);
            var actualResponse = await clientService.Get(url);

            // assert
            Assert.IsTrue(actualResponse.ResponseString.Contains(url));
            Assert.AreEqual($"{url}?{paramKey}={paramValue}", actualResponse.ResponseString);
        }
    }
}
