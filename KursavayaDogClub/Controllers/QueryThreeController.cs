using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class QueryThreeController : Controller
    {
        DogDbContext db = new DogDbContext();

        // GET: QueryThree
        public ActionResult Index()
        {
            var query = from awardsdogs in db.DOG_AWARD
                        join dog in db.DOG on awardsdogs.DOG_ID equals
                        dog.DOG_ID
                        join awards in db.AWARD on awardsdogs.AWARD_ID
                        equals awards.AWARD_ID
                        group dog by awards.AWARD_NAME into g
                        orderby g.Count()
                        select new QueryOneModel
                        {
                            Surname = g.Key,
                            Count = g.Count()
                        };

            ViewBag.count = query;
            return View();
        }
    }
}