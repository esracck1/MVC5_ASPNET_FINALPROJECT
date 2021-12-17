using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_ASPNET_FINALPROJECT.Models
{
    public class ShippingDetails
    {
        
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen adres giriniz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Lütfen ilçe giriniz.")]
        public string County { get; set; }
        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Lütfen posta kodu giriniz.")]
        public string PostCode { get; set; }
    }
}