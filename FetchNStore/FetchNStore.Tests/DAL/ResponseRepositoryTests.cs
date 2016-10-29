using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FetchNStore.Models;
using Moq;
using FetchNStore.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace FetchNStore.Tests.DAL
{
    

    [TestClass]
    public class ResponseRepositoryTests
    {

        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; }

        ResponseRepository repo { get; set; }

        public void ConnectMocksToDataStore()
        {
            var queryable_response_list = response_list.AsQueryable();


            //      Setting up mock to emulate four behaviors of an iQueryable
            mock_response_table.As<IQueryable<Response>>().Setup(Mock => Mock.Provider).Returns(queryable_response_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(Mock => Mock.Expression).Returns(queryable_response_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(Mock => Mock.ElementType).Returns(queryable_response_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(Mock => Mock.GetEnumerator()).Returns(queryable_response_list.GetEnumerator);

            //      Have Responses property return our queryable list AKA fake db table
            mock_context.Setup(a => a.Responses).Returns(mock_response_table.Object);

            //      Callbacks

            mock_response_table.Setup(c => c.Add(It.IsAny<Response>())).Callback((Response a) => response_list.Add(a));

        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();
            repo = new ResponseRepository(mock_context.Object);
            ConnectMocksToDataStore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureCanCreateInstanceOfRepo()
        {
            //Arrange//
            ResponseRepository new_repo = new ResponseRepository();
            //Act//

            //Assert//
            Assert.IsNotNull(new_repo);

        }

        [TestMethod]
        public void EnsureRepoHasContext()
        {
            ResponseRepository repo = new ResponseRepository();
            ResponseContext context = new ResponseContext();
            Assert.IsInstanceOfType(context, typeof(ResponseContext));
        }

        [TestMethod]
        public void EnsureThereAreNoResponses()
        {
            List<Response> all_responses = repo.GetAllResponses();
            int expected_count = 0;
            int all_responses_count = all_responses.Count();
            Assert.AreEqual(expected_count, all_responses_count);
        }

        [TestMethod]
        public void EnsureCanAddNewResponse()
        {
            Response response1 = new Response();
            Response response2 = new Response();

            repo.AddNewResponse(response1);
            repo.AddNewResponse(response2);
            List<Response> both_responses = repo.GetAllResponses();
            int expected_response_count = 2;
            int actual_response_count = both_responses.Count();

            Assert.AreEqual(expected_response_count, actual_response_count);

        
        }

        [TestMethod]
        public void EnsureCanAddNewResponseWithArgs()
        {
            Response response1 = new Response { Response_ID = 1, Status_Code = 200, Method = "GET", URL = "www.google.com", Response_Time = "100012", TimeOfDay = DateTime.Now };
            Response response2 = new Response { Response_ID = 2, Status_Code = 400, Method = "HEAD", URL = "www.yahoo.com", Response_Time = "100011", TimeOfDay = DateTime.Now };

            repo.AddNewResponse(response1);
            repo.AddNewResponse(response2);
            List<Response> all_responses = repo.GetAllResponses();
            int expected_response_count = 2;
            int actual_response_count = all_responses.Count();

            Assert.AreEqual(expected_response_count, actual_response_count);

        }
    }
}
