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
            var username = db.AUTORIZE.Where(x => x.LOGIN == user.LOGIN);

            if (username.Count() == 0)
            {
                db.AUTORIZE.Add(user);
                db.SaveChanges();
                return RedirectPermanent("/Home/Index");
            } else
            {
                Session["username_exist"] = "Такой пользователь уже существует";
                return Redirect("Reg");
            }      
        }
    }
}