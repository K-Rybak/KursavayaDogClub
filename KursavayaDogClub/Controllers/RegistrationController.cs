using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class RegistrationController : Controller
    {
        DogDbContext db = new DogDbContext();

        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Reg(AUTORIZE user)
        {
            db.AUTORIZE.Add(user);
            db.SaveChanges();
            return RedirectPermanent("/Home/Index");
        }
    }
}