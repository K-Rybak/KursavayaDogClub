using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class ArchiveController : Controller
    {
        DogDbContext db = new DogDbContext();
        // GET: Archive
        public ActionResult Index()
        {
            return View(db.DOG_ARCHIVE);
        }
    }
}