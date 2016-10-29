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
        Mock<DbSet<Response>> mock_reponse_table { get; set; }
        List<Response> response_list { get; set; }

        ResponseRepository repo { get; set; }

        public void ConnectMocksToDataStore()
        {
            var queryable_response_list = response_list.AsQueryable();


            //      Setting up mock to emulate four behaviors of an iQueryable
            mock_reponse_table.As<IQueryable<Response>>().Setup(Mock => Mock.Provider).Returns(queryable_response_list.Provider);
            mock_reponse_table.As<IQueryable<Response>>().Setup(Mock => Mock.Expression).Returns(queryable_response_list.Expression);
            mock_reponse_table.As<IQueryable<Response>>().Setup(Mock => Mock.ElementType).Returns(queryable_response_list.ElementType);
            mock_reponse_table.As<IQueryable<Response>>().Setup(Mock => Mock.GetEnumerator()).Returns(queryable_response_list.GetEnumerator);

            //      Have Responses property return our queryable list AKA fake db table
            mock_context.Setup(a => a.Responses).Returns(mock_response_table.Object);

            //      Callbacks

            mock_response_table.Setup(c => c.Add(It.IsAny<Response>())).Callback((Response a) => response_list.Add(a));

        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_reponse_table = new Mock<DbSet<Response>>();
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

        }
    }
}
