using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class AddNewUserController : Controller
    {
        DogDbContext db = new DogDbContext();
        // GET: AddNewUser
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "LOGIN, PASSWORD")] AUTORIZE autorize)
        {
            if (ModelState.IsValid)
            {
                db.AUTORIZE.Add(autorize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autorize);
        }
    }
}