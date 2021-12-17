using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC5_ASPNET_FINALPROJECT.Entity
{
    public class DataInitializer: DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera",Description="Kamera Ürünleri"},
                new Category(){Name="Telefon",Description="Telefon Ürünleri"},
                new Category(){Name="Bilgisayar",Description="Bilgisayar Ürünleri"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product(){Name="Canon",Description="kamera ürünmleri",Price=2500,Stock=125,IsHome=true,IsApproved=true,IsFeatured=false,Slider=true,CategoryId=1,Image="1.jpg"},
                new Product(){Name="Asus",Description="bilgisayar ürünmleri",Price=5500,Stock=15,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=2,Image="2.jpg"},
                new Product(){Name="Samsung",Description="telefon ürünleri",Price=4505,Stock=124,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=3,Image="3.jpg"},
                new Product(){Name="Lenovo",Description="bilgisayar ürünmleri",Price=9500,Stock=3,IsHome=false,IsApproved=true,IsFeatured=true,Slider=false,CategoryId=2,Image="4.jpg"}
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);

            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}