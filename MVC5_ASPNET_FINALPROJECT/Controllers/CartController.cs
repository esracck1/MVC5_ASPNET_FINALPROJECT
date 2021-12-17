using MVC5_ASPNET_FINALPROJECT.Entity;
using MVC5_ASPNET_FINALPROJECT.Identity;
using MVC5_ASPNET_FINALPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_ASPNET_FINALPROJECT.Controllers
{

    public class CartController : Controller
    {
        DataContext data = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder(Cart cart,ShippingDetails shippingDetails)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random().Next(1111, 9999).ToString());
            order.Total = cart.ProductTotal();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Address = shippingDetails.Address;
            order.City = shippingDetails.City;
            order.County = shippingDetails.County;
            order.Street = shippingDetails.Street;
            order.PostCode = shippingDetails.PostCode;
            order.OrderLine = new List<OrderLine>();
            foreach (var item in cart.Cartlines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductID = item.Product.Id;
                order.OrderLine.Add(orderline);
            }
            data.Orders.Add(order);
            data.SaveChanges();
        }





        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            if (cart.Cartlines.Count==0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart,model);
                cart.Clear();
                return View("OrderCompleted");
            }
            else
            {
                return View(model);
            }
           
        }



        public ActionResult AddToCart(int id)
        {
            var product = data.Products.FirstOrDefault(i => i.Id == id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public PartialViewResult SummaryFirst()
        {
            return PartialView(GetCart());
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }
        public ActionResult RemoveFromCart(int id)
        {
            var product = data.Products.FirstOrDefault(i => i.Id == id);
            if (product!=null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
       

        }


    }
