using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            // create a new Product object
            Product myProduct = new Product();

            // set the property
            myProduct.ProductID = 12;
            myProduct.Name = "Kayak";

            // get the property
            string productName = myProduct.Name;

            return View("Results", (object)String.Format("Product name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            // create a new Product object
            Product product = new Product();

            // set the property values
            product.ProductID = 101;
            product.Name = "Kayak";
            product.Description = "A boat for one person";
            product.Price = 275M;
            product.Category = "Watersports";

            Product myProduct = new Product
            {
                ProductID = 101,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return View("Results", (object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                {"apple", 10},
                {"orange", 20},
                {"plum", 30}
            };

            return View("Results", (object)stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Results", (object)String.Format("Total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // create and populate an array of Product objects
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPricesEnumerable();
            decimal arrayTotal = productArray.TotalPricesEnumerable();

            return View("Results", (object)String.Format("Cart Total: {0:c}, Array Total: {1:c}", cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer",  Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };
            
            decimal total = 0;
            foreach(Product product in products.FilterByCategory("Soccer"))
            {
                total += product.Price;
            }

            total = 0;
            //Func<Product, bool> categoryFilter = delegate (Product product)
            //{
            //    return product.Category == "Soccer";
            //};
            //Func<Product, bool> categoryFilter = product => product.Category == "Soccer";

            //foreach(Product product in products.Filter(categoryFilter))
            foreach(Product product in products.Filter(product => product.Category == "Soccer" || product.Price > 20))
            {
                total += product.Price;
            }
            

            return View("Results", (object)String.Format("Total: {0:c}", total));
        }

        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"}
            };

            StringBuilder result = new StringBuilder();
            foreach(var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }

            return View("Results", (object)result.ToString());
        }

        public ViewResult FindProducts()
        {
            Product[] products =
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            // define the array to hold the results
            Product[] foundProducts = new Product[3];
            // sort the contents of the array
            Array.Sort(products, (item1, item2) =>
            {
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });

            //get the first three items in the array as the results
            Array.Copy(products, foundProducts, 3);

            // using LINQ syntax
            var foundProductsLINQ = from match in products
                                    orderby match.Price descending
                                    select new { match.Name, match.Price };

            // using LINQ dot-notation syntax
            var foundProductsDotNotation = products.OrderByDescending(e => e.Price)
                                            .Take(3)
                                            .Select(e => new { e.Name, e.Price }); // deferred LINQ Extension

            var totalPrice = products.Sum(e => e.Price); // still 378.40 not > 7960
            // Non-Deferred: All, Any, Contains, Count, First, FirstOrDefault, Last, LastOrDefault, Max, Min, Single, SingleOrDefault, Sum, ToArray, ToDictionary, ToList
            // Deferred: OrderBy, OrderByDescending, Reverse, Select, SelectMany, Skip, SkipWhile, Take, TakeWhile, Where
            // A query that contains only deferred methods is not executed until the items in the result are enumerated.
            products[2] = new Product { Name = "Stadium", Price = 7960M };

            // create the result
            StringBuilder result = new StringBuilder();
            foreach (Product product in foundProducts)
            {
                result.AppendFormat("Price: {0}", product.Price);
            }

            int count = 0;
            StringBuilder result2 = new StringBuilder();
            foreach (var product in foundProductsLINQ)
            {
                result2.AppendFormat("Price: {0}", product.Price);
                if (++count == 3)
                {
                    break;
                }
            }

            StringBuilder result3 = new StringBuilder();
            foreach(var product in foundProductsDotNotation)
            {
                result3.AppendFormat("Price: {0}", product.Price);
            }

            return View("Results", (object)("Result 1: " + result.ToString() + ", Result 2: " + result2.ToString() + ", Result 3: " + result3.ToString() + ", Result 3 Total Price: " + totalPrice));
        }

        public ViewResult GetAsyncResult()
        {
            var contentLength = MyAsyncMethods.GetPageLength2();
            return View("Results", (object)String.Format("Content Length of Apress.com is: {0}", contentLength.ToString()));
        }
    }
}