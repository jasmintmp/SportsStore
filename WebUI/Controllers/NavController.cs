﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository db;
        // GET: Nav
        public NavController(IProductRepository productRepository)
        {
            db = productRepository;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = db.Products
                .Where(x=>x.Category != null)
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);  
            
            return PartialView(categories);
        }
    }
}