using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_ASPNET_FINALPROJECT.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }
       
        
    }
}