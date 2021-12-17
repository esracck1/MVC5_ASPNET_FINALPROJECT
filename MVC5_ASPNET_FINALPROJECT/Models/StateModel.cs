using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_ASPNET_FINALPROJECT.Models
{
    public class StateModel
    {
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }
        public int PendingOrderCount { get; set; }
        public int CompletedOrderCount { get; set; }
        public int PackedOrderCount { get; set; }
        public int ShipedOrderCount { get; set; }
    }
}