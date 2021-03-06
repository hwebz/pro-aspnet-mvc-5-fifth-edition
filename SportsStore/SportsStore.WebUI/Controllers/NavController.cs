﻿using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;

        public NavController(IProductsRepository repoParam)
        {
            repository = repoParam;
        }

        // GET: Nav
        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                                            .Select(x => x.Category)
                                            .Distinct()
                                            .OrderBy(x => x);

            //string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            //return PartialView(viewName, categories);
            return PartialView("FlexMenu", categories);
        }
    }
}