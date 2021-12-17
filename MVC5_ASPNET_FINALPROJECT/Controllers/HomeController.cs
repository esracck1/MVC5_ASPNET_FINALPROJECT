﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_ASPNET_FINALPROJECT.Entity;

namespace MVC5_ASPNET_FINALPROJECT.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
       public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(5).ToList());
        }
        public ActionResult Search(string q)
        {
            var p = db.Products.Where(i => i.IsApproved == true);

            if (!string.IsNullOrEmpty(q))
            {
                p = p.Where(i => i.Name.Contains(q) || i.Description.Contains(q));
                
            }
            return View(p.ToList());
        }
        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.Slider).Take(5).ToList());
        }
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public  ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i=>i.CategoryId==id).ToList());
        }

        public ActionResult Address()
        {
            return View();
        }
        public ActionResult SiteMap()
        {
            return View();
        }

    }
}
