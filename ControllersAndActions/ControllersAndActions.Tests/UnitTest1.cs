using System;
using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ControllerTest()
        {
            // arrange - create the controller
            ExampleController target = new ExampleController();

            // act - call the action method
            ViewResult result = target.Index();

            // assert - check the result
            Assert.AreEqual("HomePage", result.ViewName);
            Assert.AreEqual("Hello", result.ViewBag.Message);
        }

        [TestMethod]
        public void ViewSelectionTest()
        {
            // arrange - create the controller
            ExampleController target = new ExampleController();

            // act - call the action method
            ViewResult result = target.Index();

            // assert - check the result
            Assert.AreEqual("HomePage", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));
        }

        [TestMethod]
        public void RedirectTest()
        {
            // arrange - create the contrller
            ExampleController target = new ExampleController();

            // act - call the action method
            RedirectResult result = target.Redirect();

            // assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void RedirectPermanentTest()
        {
            // arrange - create the controller
            ExampleController target = new ExampleController();

            // act - call the action method
            RedirectResult result = target.RedirectPermanent();

            // assert - check the result
            Assert.IsTrue(result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void RedirectToRouteTest()
        {
            // arrange - create the controller
            ExampleController target = new ExampleController();

            // act - call the action method
            RedirectToRouteResult result = target.RedirectRoute();

            // assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["ID"]);
        }
        
        [TestMethod]
        public void UnauthorizedResultTest()
        {
            // arrange - create the controller
            ExampleController target = new ExampleController();

            // act - call the action method
            HttpStatusCodeResult result = target.StatusCode();

            // assert - check the result
            Assert.AreEqual(401, result.StatusCode);
        }
    }
}
