using System.Linq;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IValueCalculator calc;
        private Product[] products =
        {
            new Product { Name = "Canoe", Category = "Watersports", Price = 135000M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 270M },
            new Product { Name = "Tennis ball", Category = "Tennis", Price = 13.50M },
            new Product { Name = "Tennis net", Category = "Tennis", Price = 78.95M }
        };

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult Index()
        {
            // Basic setting of the Ninject, before setting up MVC Dependency Injection
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            // Without Ninject we're still have a problem
            //IValueCalculator calc = new LinqValueCalculator();

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}