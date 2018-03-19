using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class RegistrationController : Controller
    {
        BakeryEntities db = new BakeryEntities();

        // GET: Registration
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register([Bind(Include = "PersonLastName, PersonFirstName, PersonEmail, PersonPhone")] NewPerson np)
        {
            Person p = new Person
            {
                PersonLastName = np.PersonLastName,
                PersonFirstName = np.PersonFirstName,
                PersonEmail = np.PersonEmail,
                PersonPhone = np.PersonPhone,
                PersonDateAdded = DateTime.Now
            };

            db.People.Add(p);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "User successfully registered!";

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}
