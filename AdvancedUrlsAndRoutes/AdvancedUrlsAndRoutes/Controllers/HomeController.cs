using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedUrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult CustomVariable(string id = "DefaultIdInAction", string catchall = "")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            //ViewBag.CustomVariable = RouteData.Values["id"];
            //ViewBag.CustomVariable = id;
            ViewBag.CustomVariable = id ?? "<no value>";
            ViewBag.CatchAll = catchall ?? "<no value>";
            return View();
        }

        public ViewResult MyActionMethod()
        {
            string myActionUrl = Url.Action("Index", new { id = "MyID" });
            string myRouteUrl = Url.RouteUrl(new { controller = "Home", action = "Index" });
            // ... do something with URLs ...
            return View();
        }

        public RedirectToRouteResult MyAnotherMethod()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index", id = "MyID" });
        }
    }
}