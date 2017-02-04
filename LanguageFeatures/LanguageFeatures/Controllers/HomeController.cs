using System;
using System.Collections.Generic;
using System.Text;
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

        public ViewResult UseExtension()
        {
            //create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Canoe", Price = 99M },
                    new Product { Name = "Lifejacket", Price = 42.35M },
                    new Product { Name = "Basketball ball", Price = 13.50M },
                    new Product { Name = "Basket net", Price = 9.60M }
                }
            };

            //get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            //create and populate MyShoppingCart
            IEnumerable<Product> products = new MyShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Canoe", Price = 99M },
                    new Product { Name = "Lifejacket", Price = 42.35M },
                    new Product { Name = "Basketball ball", Price = 13.50M },
                    new Product { Name = "Basket net", Price = 9.60M }
                }
            };

            //create and populate an array of Product objects
            Product[] productArray =
            {
                    new Product { Name = "Canoe", Price = 99M },
                    new Product { Name = "Lifejacket", Price = 42.35M },
                    new Product { Name = "Basketball ball", Price = 13.50M },
                    new Product { Name = "Basket net", Price = 9.60M }
            };

            //get the total value of the products in the cart
            decimal cartTotal = products.MyTotalPrices();
            decimal arrayTotal = productArray.MyTotalPrices();

            return View("Result", (object)String.Format("Cart total: {0:c}, Array total: {1:c}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            //create and populate MyShoppingCart
            IEnumerable<Product> products = new MyShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 99M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 13.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 9.60M }
                }
            };

            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Basketball"))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult MyUseFilterExtensionMethod_1()
        {
            //create and populate MyShoppingCart
            IEnumerable<Product> products = new MyShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 99M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 13.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 9.60M }
                }
            };

            Func<Product, bool> categoryFilter = prod => prod.Category == "Basketball";

            decimal total = 0;
            foreach (Product prod in products.Filter(categoryFilter))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult MyUseFilterExtensionMethod_2()
        {
            //create and populate MyShoppingCart
            IEnumerable<Product> products = new MyShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 99M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 13.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 9.60M }
                }
            };

            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Basketball"))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult MyUseFilterExtensionMethod()
        {
            //create and populate MyShoppingCart
            IEnumerable<Product> products = new MyShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 99M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 13.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 9.60M }
                }
            };

            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Basketball" && prod.Price < 10))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name = "MVC", Category = "Pattern"},
                new {Name = "Hat", Category = "Clothing"},
                new {Name = "Cucumber", Category = "Plant"}
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" - ");
            }
            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProducts()
        {
            Product[] products =
            {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 9M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 3.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 15.60M }
            };

            //define array to hold the result
            Product[] foundProducts = new Product[3];
            //sort the contents of the array
            Array.Sort(products, (item1, item2) =>
            {
                return Comparer<decimal>.Default.Compare(item2.Price, item1.Price);
            });
            //get the first three items in the array as the result
            Array.Copy(products, foundProducts, 3);

            //create the result
            StringBuilder result = new StringBuilder();
            foreach (Product prod in foundProducts)
            {
                result.AppendFormat("Price: {0}; ", prod.Price);
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProductsLINQ()
        {
            Product[] products =
            {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 9M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 3.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 15.60M }
            };

            var foundProducts = from match in products
                                orderby match.Price ascending
                                select new { match.Name, match.Price };

            //create the result
            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var prod in foundProducts)
            {
                result.AppendFormat("Price: {0}; ", prod.Price);
                if (++count == 3)
                {
                    break;
                }
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProductsLINQDot()
        {
            Product[] products =
            {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 9M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 3.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 15.60M }
            };

            var foundProducts = products.OrderByDescending(e => e.Price)
                                .Take(3)
                                .Select(e => new { e.Name, e.Price });

            //create the result
            StringBuilder result = new StringBuilder();
            foreach (var prod in foundProducts)
            {
                result.AppendFormat("Price: {0}; ", prod.Price);
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProductsDefLINQDot()
        {
            Product[] products =
            {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 9M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 3.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 15.60M }
            };

            var foundProducts = products.OrderByDescending(e => e.Price)
                                .Take(3)
                                .Select(e => new { e.Name, e.Price });

            products[2] = new Product { Name = "Stadium", Price = 96750M };

            //create the result
            StringBuilder result = new StringBuilder();
            foreach (var prod in foundProducts)
            {
                result.AppendFormat("Price: {0}; ", prod.Price);
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult SumProducts()
        {
            Product[] products =
            {
                    new Product { Name = "Canoe", Category = "Watersports", Price = 9M },
                    new Product { Name = "Lifejacket", Category = "Watersports", Price = 42.35M },
                    new Product { Name = "Basketball ball", Category = "Basketball", Price = 3.50M },
                    new Product { Name = "Basket net", Category = "Basketball", Price = 15.60M }
            };

            var results = products.Sum(e => e.Price);

            products[2] = new Product { Name = "Stadium", Price = 96750M };

            return View("Result", (object)String.Format("Sum: {0}", results));
        }

    }
}