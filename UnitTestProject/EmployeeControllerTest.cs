using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmployeeSystem.Controllers;
using EmployeeSystem.Model;
using EmployeeSystem.Model.IRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Moq;
using PagedList;

namespace UnitTestProject
{
    /// <summary>
    ///This is a test class for EmployeeControllerTest and is intended
    ///to contain all EmployeeControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeRepository> mockEmployeeRepository;
        private Mock<ICompanyRepository> mockCompanyRepository;
        private EmployeeController target;
        private InMemoryDatabase data = new InMemoryDatabase();

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void TestInitialize()
        {
            mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockCompanyRepository = new Mock<ICompanyRepository>();
            mockEmployeeRepository.Setup(ex => ex.FindBy("Name", "James Shi"))
                .Returns(data.Employees.Where(e => e.Name == "James Shi").AsQueryable());
            mockEmployeeRepository.Setup(ex => ex.FindAll())
                .Returns(data.Employees.AsQueryable());
            target = new EmployeeController(mockEmployeeRepository.Object, mockCompanyRepository.Object);
        }

        [TestMethod()]
        public void IndexTestFindEmployeeByName()
        {
            string property = "Name";
            string value = "James Shi";
            int pageNumber = 1;
            int pageSize = 5;

            ViewResult actual = target.Index(property, value, pageNumber, pageSize);

            Assert.AreEqual(1, ((IPagedList<Employee>)actual.ViewData.Model).Count);
            Assert.AreEqual("James Shi", ((IPagedList<Employee>)actual.ViewData.Model).First().Name);
            Assert.AreEqual(1, ((IPagedList<Employee>)actual.ViewData.Model).TotalItemCount);
        }

        [TestMethod()]
        public void IndexTestListAllEmployees()
        {
            string property = string.Empty;
            string value = string.Empty;
            int pageNumber = 1;
            int pageSize = 5;

            ViewResult actual = target.Index(property, value, pageNumber, pageSize);

            Assert.AreEqual(5, ((IPagedList<Employee>)actual.ViewData.Model).Count);
            Assert.AreEqual(1, ((IPagedList<Employee>)actual.ViewData.Model).First().ID);
            Assert.AreEqual(8, ((IPagedList<Employee>)actual.ViewData.Model).TotalItemCount);
        }
    }
}
