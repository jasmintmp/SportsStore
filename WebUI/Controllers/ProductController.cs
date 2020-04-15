using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        
        private IProductRepository db;
        public int PageSize = 2;

        public ProductController(IProductRepository productRepository)
        {
            db = productRepository;
        }
        // GET: Product https://localhost:44341/product/list
        public ViewResult List(int page = 1)
        { 
            return View(db.Products
                .OrderBy(p=> p.ProductID)
                .Skip(PageSize * (page -1))
                .Take(PageSize));
            //return View(db.Products.ToList());
        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "CarId,Brand,Model")] Product product)
//        {
//            if (ModelState.IsValid)
//            {
////                db.Products.Add(carModel);
//    //            db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//  //          return View(carModel);
//        }
    }
}