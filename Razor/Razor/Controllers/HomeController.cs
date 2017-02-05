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
    }
}