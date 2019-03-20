using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Filters.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        [Authorize]
        //[OutputCache(Duration = 60)]
        public ViewResult Index()
        {
            //if (!Request.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            return View();
        }

        [Authorize]
        public ViewResult Create()
        {
            //if (!Request.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            return View();
        }

        [Authorize]
        public ViewResult Edit()
        {
            //if (!Request.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            return View();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View();
            }
        }
    }
}