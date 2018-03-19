using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bakery.Models
{
    public class Item
    {
        public int ProductKey { get; set; }
        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}