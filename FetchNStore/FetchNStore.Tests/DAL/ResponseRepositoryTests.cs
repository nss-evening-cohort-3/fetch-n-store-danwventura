using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FetchNStore.Models;

namespace FetchNStore.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTests
    {
        [TestMethod]
        public void EnsureCanCreateInstanceOfResponseClass()
        {
            //Arrange//
            Response new_response = new Response();
            //Act//

            //Assert//
            Assert.IsNotNull(new_response);

        }
    }
}
