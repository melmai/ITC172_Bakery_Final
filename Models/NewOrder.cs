using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bakery.Models
{
    public class NewOrder
    {
        /* Sale Details */
        public int SaleDetailQuantity { get; set; }
        public int ProductKey { get; set; }
        public decimal SaleDetailPriceCharged { get; set; }
        public decimal SaleDetailSaleTaxPercent { get; set; }
    }
}