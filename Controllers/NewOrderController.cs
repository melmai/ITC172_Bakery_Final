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

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "PersonLastName, PersonFirstName, PersonEmail, PersonPhone")] NewOrder order)
        {
            Person person = new Person();
            person.PersonLastName = order.PersonLastName;
            person.PersonFirstName = order.PersonFirstName;
            person.PersonEmail = order.PersonEmail;
            person.PersonPhone = order.PersonPhone;
            person.PersonDateAdded = DateTime.Now;
            db.People.Add(person);

            Sale sale = new Sale();
            sale.SaleDate = DateTime.Now;

            db.SaveChanges();

            return View();
        }
    }
}