using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class QueryTwoController : Controller
    {
        DogDbContext db = new DogDbContext();
        // GET: QueryTwo
        public ActionResult Index()
        {
            // при помощи GroupJoin связываем и группируем по породам
            var query = db.BREED.GroupJoin(
                db.DOG,
                d => d.BREED_ID,
                br => br.ID_BREED,
                (dg, bre) => new QueryOneModel
                {
                    Surname = dg.BREED_NAME,
                    Count = bre.Count(),
                    EarlyDate = bre.Select(d => d.BIRTH_DATE).Min(),
                    LaterDate = bre.Select(d => d.BIRTH_DATE).Max()
                });
            
            ViewBag.count = query.ToList();

            return View();
            
        }
    }
}