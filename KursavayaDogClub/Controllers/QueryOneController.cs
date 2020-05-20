using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class QueryOneController : Controller
    {
        DogDbContext db = new DogDbContext();

        // GET: QueryOne
        // Запрос выводит на страницу список владельцов
        // имеющих двух и более собак
        public ActionResult Index()
        {
            var query = from owner in db.OWNER
                        join dog in db.DOG on owner.OWNER_ID equals
                        dog.OWNER_ID
                        group dog by owner.OWNER_SURNAME into g
                        where g.Count() >= 2
                        select new QueryOneModel
                        {
                            Surname = g.Key,
                            Count = g.Count()
                        };

            ViewBag.count = query.ToList();
                       
            return View();
        }
    }
}