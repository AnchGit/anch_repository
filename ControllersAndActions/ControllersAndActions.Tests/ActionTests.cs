using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControllersAndActions.Controllers;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            // Arrange
            // Создание контроллера
            ExampleController target = new ExampleController();

            // Act
            // Вызов метода действия
            //ViewResult result = target.Index();
            //RedirectResult result = target.Redirect();
            //RedirectToRouteResult result = target.Redirect();
            HttpStatusCodeResult result = target.StatusCode();

            // Assert
            // Проверка результата
            //Assert.AreEqual("", result.ViewName);
            //Assert.AreEqual("Hello", result.ViewBag.Message);
            //Assert.IsTrue(result.Permanent);
            //Assert.AreEqual("/Example/Index", result.Url);
            //Assert.IsFalse(result.Permanent);
            //Assert.AreEqual("Example", result.RouteValues["controller"]);
            //Assert.AreEqual("Index", result.RouteValues["action"]);
            //Assert.AreEqual("MyID", result.RouteValues["ID"]);
            Assert.AreEqual(401, result.StatusCode;
        }

        [TestMethod]
        public void ViewSelectionTest()
        {
            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            ViewResult result = target.Index();

            // Asert - check the result
            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(System.DateTime));
        }
    }
}
