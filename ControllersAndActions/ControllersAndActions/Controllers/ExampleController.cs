using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.Message = TempData["Message"] ?? "Hello";
            ViewBag.Date = TempData["Date"] ?? DateTime.Now;
            return View("HomePage", date);
        }

        public RedirectResult Redirect()
        {
            return Redirect("/Example/Index");
        }

        public RedirectResult RedirectPermanent()
        {
            return RedirectPermanent("/Example/Index");
        }

        public RedirectToRouteResult RedirectRoute()
        {
            return RedirectToRoute(new
            {
                controller = "Example",
                action = "Index",
                ID = "MyID"
            });
        }

        public RedirectToRouteResult RedirectAction()
        {
            TempData["Message"] = "Hello from TempData";
            TempData["Date"] = new DateTime(2019, 1, 5);
            TempData.Keep("Message");
            TempData.Keep("Date");
            return RedirectToAction("Index");
        }

        public HttpStatusCodeResult StatusCode()
        {
            //return new HttpStatusCodeResult(404, "URL cannot be service");
            //return HttpNotFound();
            return new HttpUnauthorizedResult();
        }
    }
}