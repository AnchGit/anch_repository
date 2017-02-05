using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Product[] products =
        {
            new Product { Name = "Canoe", Category = "Watersports", Price = 135000M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 270M },
            new Product { Name = "Tennis ball", Category = "Tennis", Price = 13.50M },
            new Product { Name = "Tennis net", Category = "Tennis", Price = 78.95M }
        };
        public ActionResult Index()
        {
            LinqValueCalculator calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}