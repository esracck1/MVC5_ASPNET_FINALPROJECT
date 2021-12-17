using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_ASPNET_FINALPROJECT.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}