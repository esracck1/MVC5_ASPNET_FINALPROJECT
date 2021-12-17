using MVC5_ASPNET_FINALPROJECT.Entity;
using MVC5_ASPNET_FINALPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_ASPNET_FINALPROJECT.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            StateModel model = new StateModel();
            model.PendingOrderCount = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.CompletedOrderCount = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.PackedOrderCount = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.ShipedOrderCount = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.ProductCount = db.Products.Count();
            model.OrderCount = db.Orders.Count();
            return View(model);
        }
       public PartialViewResult NotificationMenu()
        {
            var notif = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(notif);
        }



    }
}