using ControllersAndActions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

        public ActionResult RenameProduct()
        {
            // access various properties from context objects
            string userName = User.Identity.Name;
            string serverName = Server.MachineName;
            string clientIP = Request.UserHostAddress;
            DateTime dateStamp = HttpContext.Timestamp;
            AuditRequest(userName, serverName, clientIP, dateStamp, "Renaming product");

            // Retrieve posted data from Request.Form
            string oldProductName = Request.Form["OldName"];
            string newProductName = Request.Form["NewName"];
            bool result = AttemptProductRename(oldProductName, newProductName);

            ViewData["RenameResult"] = result;
            return View("ProductRenamed");
        }

        public ActionResult ShowWeatherForecast(string city, DateTime forDate)
        {
            //string city = (string)RouteData.Values["city"];
            //DateTime forDate = DateTime.Parse(Request.Form["forDate"]);
            return View();
        }

        public ActionResult ProductOutput()
        {
            //if (Server.MachineName == "TINY")
            //{
            //    //Response.Redirect("/Basic/Index");
            //    return new CustomRedirectResult { Url = "/Basic/Index" };
            //} else
            //{
            //    Response.Write("Controller: Derived, Action: ProductOutput");
            //}
            //return new RedirectResult("/Basic/Index");
            return Redirect("/Basic/Index");
        }

        private bool AttemptProductRename(string oldProductName, string newProductName)
        {
            return oldProductName != newProductName;
        }

        private void AuditRequest(string userName, string serverName, string clientIP, DateTime dateStamp, string v)
        {
            System.Console.WriteLine(string.Format("User Name: {0}, Server name: {1}, Client IP: {2}, Date: {3}", userName, serverName, clientIP, dateStamp.ToShortDateString()));
        }
    }
}