using ControllerExtensibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace ControllerExtensibility.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class FastController : Controller
    {
        // GET: Fast
        public ActionResult Index()
        {
            //Session["Message"] = "Message from Fast controller"; // Session is disabled, controller will throw an exception
            return View("Result", new Result {
                ControllerName = "Fast",
                ActionName = "Index"
            });
        }
    }
}