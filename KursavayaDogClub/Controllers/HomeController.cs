using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class HomeController : Controller
    {
        DogDbContext db = new DogDbContext();

        public ActionResult Index()
        {
            Session["user"] = null;

            return View();
        }

        [HttpPost]
        public RedirectResult Index(string username, string password)
        {
            AUTORIZE autification = db.AUTORIZE.FirstOrDefault(x => x.LOGIN == username && x.PASSWORD == password);

            if (autification != null)
            {
                Session["user"] = autification.LOGIN;
                //USERJOURNAL journal = new USERJOURNAL();
                //journal.LOGIN_JOURNAL = username;
                //journal.TIME_JOURNAL = DateTime.Now;
                //db.USERJOURNAL.Add(journal);
                //db.SaveChanges(); //Записывается в журнал
                return RedirectPermanent("/DOGsPage/Index");
            } else
            {
                Session["error"] = "Неправильный логин/пароль";
                return Redirect("/");
            }

        }
    }
}