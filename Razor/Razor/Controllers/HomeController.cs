using System.Web.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Canoe",
            Description = "A boat for one person",
            Category = "Watersport",
            Price = 240M
        };
        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array =
            {
                new Product { Name = "Battleship", Price = 135000M },
                new Product { Name = "Boat", Price = 270M },
                new Product { Name = "Tennis ball", Price = 13.50M },
                new Product { Name = "Tennis net", Price = 78.95M }
            };
            return View(array);
        }
    }
}