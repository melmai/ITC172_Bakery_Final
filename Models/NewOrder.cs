using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bakery.Models
{
    public class NewOrder
    {
        /* Person Registration */
        public string PersonLastName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPhone { get; set; }

        /* Sale Details */
        public int SaleDetailQuantity { get; set; }
        public int ProductKey { get; set; }
        public decimal SaleDetailPriceCharged { get; set; }
        public decimal SaleDetailSaleTaxPercent { get; set; }
    }
}