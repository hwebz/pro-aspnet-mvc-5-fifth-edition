using HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private PartialPerson[] personData =
        {
            new PartialPerson {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new PartialPerson {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new PartialPerson {FirstName = "John", LastName = "Smith", Role = Role.User},
            new PartialPerson {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetPeople()
        //{
        //    return View(personData);
        //}

        //[HttpPost]
        public ActionResult GetPeople(string selectedRole = "All")
        {
            //if (selectedRole == null || selectedRole == "All")
            //{
            //    return View(personData);
            //} else
            //{
            //    Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
            //    return View(personData.Where(p => p.Role == selected));
            //}
            return View((object)selectedRole);
        }

        public PartialViewResult GetPeopleAjax(string selectedRole = "All") {
            return PartialView(GetData(selectedRole));
        }

        private IEnumerable<PartialPerson> GetData(string selectedRole)
        {
            IEnumerable<PartialPerson> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var data = GetData(selectedRole).Select(p => new {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Role = Enum.GetName(typeof(Role), p.Role)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<PartialPerson> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            if (Request.IsAjaxRequest())
            {
                var formattedData = data.Select(p => new
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = Enum.GetName(typeof(Role), p.Role)
                });
                return Json(formattedData, JsonRequestBehavior.AllowGet);
            } else
            {
                return PartialView("GetPeopleAjax", data);
            }
        }
    }
}