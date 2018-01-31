﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestApp.Controllers;
using System.Web.Mvc;

namespace UnitTestApp.Tests.Controllers
{
    [TestClass]
    public class StoreContollerTest
    {
        private StoreController controller;
        private ViewResult result;

        [TestInitialize]
        public void SetupContest()
        {
             controller = new StoreController();
             result = controller.Index() as ViewResult;
        }
        [TestMethod]
        public void IndexViewREsiltNotNull()
        {

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexStringInViewbag()
        {

            Assert.AreEqual("Hello world!", result.ViewBag.Massage);
        }
        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
