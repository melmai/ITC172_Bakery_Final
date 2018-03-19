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
            return View();
        }

    }
}