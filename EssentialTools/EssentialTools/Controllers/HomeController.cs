using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private IValueCalculatorDiscount calcDiscount;
        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        // in Output window when debugging you can see the counter = 2 instances
        public HomeController(IValueCalculator calcParam, IValueCalculator calcParam2, IValueCalculatorDiscount calcDiscountParam) // constructor injection
        {
            calc = calcParam;
            calcDiscount = calcDiscountParam;
        }

        // GET: Home
        public ActionResult Index()
        {
            LinqValueCalculator calc = new LinqValueCalculator();

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }

        public ActionResult DependencyInjection()
        {
            IValueCalculator calc = new LinqValueCalculator(); // Implement Dependency Injection

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View("Index", totalValue);
        }

        public ActionResult NinjectDependencyResolver()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View("Index", totalValue);
        }

        public ActionResult NinjectDependencyResolverMVC()
        {
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View("Index", totalValue);
        }

        public ActionResult NinjectDependencyResolverMVCChain()
        {
            ShoppingCartDiscount cart = new ShoppingCartDiscount(calcDiscount) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View("Index", totalValue);
        }
    }
}