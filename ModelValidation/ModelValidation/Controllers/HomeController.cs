using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            // validation in action method
            //if (string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError("ClientName", "[Action Method-Validation] Please enter your name"); // property-level validation
            //}

            //if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
            //{
            //    ModelState.AddModelError("Date", "[Action Method-Validation] Please enter a date in the feature"); // property-level validation => Html.ValidationSummary(false) shows all levels of validation errors
            //}

            //if (!appt.TermsAccepted)
            //{
            //    ModelState.AddModelError("TermsAccepted", "[Action Method-Validation] You must accept the terms"); // property-level validation
            //}

            //if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date") && appt.ClientName == "Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday)
            //{
            //    ModelState.AddModelError("", "[Action Method-Validation] Joe cannot book appointment on Mondays"); // model-level validation => Html.ValidationSummary(true) only show mode-level validation errors
            //}

            if (ModelState.IsValid)
            {
                // statements to store new Appointment in a
                // repository would go here in a real project
                return View("Completed", appt);
            }
            return View();
        }

        public JsonResult ValidateDate(string Date)
        {

            if (!DateTime.TryParse(Date, out DateTime parseDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)", JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now > parseDate)
            {
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateJoe(Appointment app)
        {
            if (app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday)
            {
                return Json("[Remote-Validation] Joe cannot make appoitments on Mondays", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}