using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

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
        public ViewResult List(string category, int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItemsInCategory = db.Products.Count(p => p.Category == category),
                ItemsPerPage = PageSize
            };

            var productListViewModel = new ProductListViewModel() { 
                Products = db.Products
                .Where(p => p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = pagingInfo, 
                CurrentCategory = category
            };
            return View(productListViewModel);
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