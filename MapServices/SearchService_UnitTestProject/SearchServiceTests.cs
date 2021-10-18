//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using SearchService.Controllers;
using SearchService.Interface;
using SearchService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchService_UnitTestProject
{
    public class SearchServiceTests
    {
        private ILogger<SearchController> logger;
        private ISearchApiClient searchApi;
        [SetUp]
        public void Setup()
        {
            logger = Substitute.For<ILogger<SearchController>>();
            searchApi = Substitute.For<ISearchApiClient>();
        }

        [Test]
        public async Task Validate_SearchLocationInputEmpty_ReturnsBadRequest()
        {
            SearchController controller = new SearchController(logger, searchApi);

            var response = await controller.GetSearchLocationAsync(address: string.Empty) as BadRequestResult;

            Assert.NotNull(response);
            Assert.AreEqual(response.StatusCode, 400);
        }

        [Test]
        public async Task Validate_SearchAPITokenRequestReturnsBadRequest_ReturnsUnAuthorized()
        {
            searchApi.GetSearchAsync(Arg.Any<string>()).Returns(Task.FromException<List<SearchView>>(new UnauthorizedAccessException("GIS token access error")));
            SearchController controller = new SearchController(logger, searchApi);

            var response = await controller.GetSearchLocationAsync(address: "Test") as UnauthorizedResult;

            Assert.NotNull(response);
            Assert.AreEqual(response.StatusCode, 401);
        }

        [Test]
        public async Task Validate_SearchAPIThrowsException_ReturnsInternalServerError()
        {
            searchApi.GetSearchAsync(Arg.Any<string>()).Returns(Task.FromException<List<SearchView>>(new Exception("GIS token access error")));
            SearchController controller = new SearchController(logger, searchApi);

            var response = await controller.GetSearchLocationAsync(address: "Test") as StatusCodeResult;

            Assert.NotNull(response);
            Assert.AreEqual(response.StatusCode, 500);
        }

        [Test]
        public async Task Validate_SearchAPIReturnsEmpty_ReturnsNoContent()
        {
            searchApi.GetSearchAsync(Arg.Any<string>()).Returns(Task.FromResult(new List<SearchView>()));
            SearchController controller = new SearchController(logger, searchApi);

            var response = await controller.GetSearchLocationAsync(address: "Test") as NoContentResult;

            Assert.NotNull(response);
            Assert.AreEqual(response.StatusCode, 204);
        }

        [Test]
        public async Task Validate_SearchAPIReturnsLocationList_ReturnsOk()
        {
            searchApi.GetSearchAsync(Arg.Any<string>()).Returns(Task.FromResult(new List<SearchView>() { new SearchView { Place = "Test" } }));
            SearchController controller = new SearchController(logger, searchApi);

            var response = await controller.GetSearchLocationAsync(address: "Test") as OkObjectResult;

            Assert.NotNull(response);
            Assert.AreEqual(response.StatusCode, 200);
        }

       
    }
}