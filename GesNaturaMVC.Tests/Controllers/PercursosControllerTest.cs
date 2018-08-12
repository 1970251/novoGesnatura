using System;
using System.Web.Mvc;
using GesNaturaMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GesNaturaMVC.Tests.Controllers
{
    [TestClass]
    public class PercursosControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new PercursosController();
            var result = controller.Details(59) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);

        }
    }
}
