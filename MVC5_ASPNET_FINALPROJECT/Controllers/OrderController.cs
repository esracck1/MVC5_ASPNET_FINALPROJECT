using MVC5_ASPNET_FINALPROJECT.Entity;
using MVC5_ASPNET_FINALPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_ASPNET_FINALPROJECT.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrder()
            {
                Id=i.Id,
                OrderNumber=i.OrderNumber,
                OrderDate=i.OrderDate,
                OrderState=i.OrderState,
                Total=i.Total,
                Count=i.OrderLine.Count
            }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                orderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Address = i.Address,
                City = i.City,
                County = i.County,
                Street = i.Street,
                PostCode = i.PostCode,
                OrderLineModels = i.OrderLine.Select(x => new OrderLineModel()
                {
                    ProductId=x.ProductID,
                    Image=x.Product.Image,
                    ProductName=x.Product.Name,
                    Quantity=x.Quantity,
                    Price=x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }
        public ActionResult UpdateOrderState(int orderId,OrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == orderId);
            if (order!=null)
            {
                order.OrderState = orderState;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgileriniz güncellendi.";
                return RedirectToAction("Details", new { id=orderId});
            }
            return RedirectToAction("Index");
        }


        public ActionResult PendingOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult CompletedOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList();
            return View(model);
        }
        public ActionResult PackedOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(model);
        }
        public ActionResult ShipedOrders()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(model);
        }
    }
}