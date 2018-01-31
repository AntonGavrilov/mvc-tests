using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqMvcApp;
using MoqMvcApp.Controllers;
using Moq;
using MoqMvcApp.Models;

namespace MoqMvcApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewModelNotNull()
        {

            //Arrange
            var mock = new Mock<IRepository>();

            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());

            HomeController controller = new HomeController(mock.Object);

            //Act
            var result = controller.Index() as ViewResult;
                
            //Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexModelListCountIs1()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>() { new Computer() });
            HomeController controller = new HomeController(mock.Object);
            var expected = 1;

            //Act
            var actual = ((controller.Index() as ViewResult).Model as List<Computer>).Count;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IndexModelListCountIs2()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>() { new Computer(), new Computer() });
            HomeController controller = new HomeController(mock.Object);
            var expected = 2;

            //Act
            var actual = ((controller.Index() as ViewResult).Model as List<Computer>).Count;

            //Assert
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            //Arrange
            string expected = "Create";
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");

            //act
            ViewResult result = controller.Create(comp) as ViewResult;

            //assert

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);


        }


        [TestMethod]
        public void CreatePostAction_SaveModel()
        {
            //arrange
            var mock = new Mock<IRepository>();
            Computer comp = new Computer();
            HomeController controller = new HomeController(mock.Object);

            //act
            RedirectToRouteResult result = controller.Create(comp) as RedirectToRouteResult;

            //assert
            mock.Verify(a => a.Create(comp));
            mock.Verify(a => a.Save());

        }


        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("hui", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
