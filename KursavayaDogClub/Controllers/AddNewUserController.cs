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
            //Проверка на имеющегося пользователя в таблице
            var user = db.AUTORIZE.Where(x => x.LOGIN == autorize.LOGIN).Select(x => x.ID_USER).ToString();

            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    db.AUTORIZE.Add(autorize);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            return View(autorize);
        }
    }
}