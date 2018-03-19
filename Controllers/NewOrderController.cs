using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class NewOrderController : Controller
    {
        BakeryEntities db = new BakeryEntities();

        // GET: NewOrder
        public ActionResult Index()
        {
            ViewBag.CustomerKey = new SelectList(db.People, "PersonKey", "PersonEmail");
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeKey");
            ViewBag.ProductKey = new SelectList(db.Products, "ProductKey", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include ="CustomerKey, EmployeeKey, SaleDetailQuantity, ProductKey")] NewOrder no)
        {
            Sale sale = new Sale();
            sale.SaleDate = DateTime.Now;
            sale.CustomerKey = no.CustomerKey;
            sale.EmployeeKey = no.EmployeeKey;
            db.Sales.Add(sale);
            db.SaveChanges();

            SaleDetail sd = new SaleDetail();
            int salekey = (from order in db.Sales
                          where order.SaleDate.Equals(sale.SaleDate)
                          select order.SaleKey).FirstOrDefault();
            sd.SaleKey = (int)salekey;
            sd.ProductKey = no.ProductKey;
            sd.SaleDetailQuantity = no.SaleDetailQuantity;
            sd.SaleDetailPriceCharged = (from product in db.Products
                                         where product.ProductKey.Equals(no.ProductKey)
                                         select product.ProductPrice).FirstOrDefault();
            sd.SaleDetailSaleTaxPercent = (decimal)0.09;
            db.SaleDetails.Add(sd);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Order Complete!";

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }

     

    }

}