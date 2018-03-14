using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BakeryEntities db = new BakeryEntities();
            return View(db.Products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Baking since 2018";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please contact us for special orders and catering events.";

            return View();
        }
    }
}