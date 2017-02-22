using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // Создать имитированный запрос
            // create the mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // Создать имитированный ответ
            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // Создать имитированный контекст, используя запрос и ответ
            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // Возвратить имитированный контекст
            // return the mocked context
            return mockContext.Object;
        }

        private void TestRoteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
            // Организация
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Действие - обработка маршрута
            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Утверждение
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) => { return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0; };

            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRoteFail(string url)
        {
            // Организация
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Действие - обработка маршрута
            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            // Утверждение
            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        [TestMethod]
        public void TestIncomingRoutes()
        {
            // Проверить URL, который мы надеемся получить
            // check for the URL that is hoped for
            TestRoteMatch("~/Admin/Index", "Admin", "Index");

            // Проверить значения, получаемые из сегментов
            // check that the values are being obtained from the segments
            TestRoteMatch("~/One/Two", "One", "Two");

            // Удостовериться, что слишком много или слишком мало сегмнтов не приводя к совпадению
            // ensure that too many or too few segments fails to match
            TestRoteFail("~/Admin/Index/Segment");
            TestRoteFail("~/Admin");
        }
    }
}
