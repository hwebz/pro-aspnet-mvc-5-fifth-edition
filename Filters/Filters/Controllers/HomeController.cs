using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch timer;

        //[CustomAuth(false)]
        [Authorize(Users = "admin")]
        // GET: Home
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [GoogleAuth]
        [Authorize(Users = "bob@google.com")] // when you logged in, you logout also. have to login again and again.
        public string List()
        {
            return "This is the List action on the Home controller";
        }

        //[RangeException]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return string.Format("The id value is: {0}", id);
            } else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }

        //[CustomAction]
        [ProfileAction]
        [ProfileResult]
        [ProfileAll]
        public string FilterTest()
        {
            return "This is the FilterTest action";
        }

        public string OtherFilterTest()
        {
            return "This is the another filter test";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(string.Format("<div>Total elapsed time (in controller): {0:F6}</div>", timer.Elapsed.TotalSeconds));
        }
    }
}