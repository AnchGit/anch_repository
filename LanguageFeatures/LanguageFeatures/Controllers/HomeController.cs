using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to URL to show example.";
        }

        public ViewResult AutoProperty()
        {
            //create a new Product object
            Product myProduct = new Product();
            //set the property value
            myProduct.Name = "Canoe";
            //get the property
            string productName = myProduct.Name;
            //generate the View
            return View("Result", (object)String.Format("Product name : {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            //create and populate new Product object
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Canoe",
                Description = "A boat for one person",
                Price = 3699M,
                Category = "Watersports"
            };

            return View("Result", (object)String.Format("Category: {0}; Name: {1}", myProduct.Category, myProduct.Name));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "cucumber" };
            List<int> intList = new List<int> { 10, 20, 30, 42 };
            Dictionary<string, int> myDict = new Dictionary<string, int> { { "apple", 10 }, { "orange", 20 }, { "cucumber", 42 } };

            return View("Result", (object)stringArray[2]);
        }
    }
}