using MVC5_ASPNET_FINALPROJECT.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_ASPNET_FINALPROJECT.Models
{
    public class Cart
    {
        private List<Cartline> _cartline = new List<Cartline>();
        public List<Cartline> Cartlines
        {
            get{ return _cartline; }
        }
        public void AddProduct(Product product,int quantity)
        {
            var line = _cartline.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line==null)
            {
                _cartline.Add(new Cartline() { Product = product, Quantity = quantity });

            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartline.RemoveAll(i => i.Product.Id == product.Id);
        }
        public double ProductTotal()
        {
            return _cartline.Sum(i => i.Product.Price * i.Quantity);
        }
        public void Clear()
        {
            _cartline.Clear(); 
        }
    }
    public class Cartline
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}