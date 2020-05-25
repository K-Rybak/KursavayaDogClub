using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class CandidateController : Controller
    {
        DogDbContext db = new DogDbContext();

        // GET: Candidate
        public ActionResult Index()
        {
            ViewBag.ID_BREED = new SelectList(db.BREED, "BREED_ID", "BREED_NAME");
            return View();
        }

        // запрос на подбор кандидатур
        [HttpPost]
        public ActionResult GetDogs(int? BREED_ID)
        {
            var query = from awardsdogs in db.DOG_AWARD
                        join dogs in db.DOG on awardsdogs.DOG_ID equals
                        dogs.DOG_ID
                        join awards in db.AWARD on awardsdogs.AWARD_ID
                        equals awards.AWARD_ID
                        join breeds in db.BREED on dogs.ID_BREED equals
                        breeds.BREED_ID
                        join owners in db.OWNER on dogs.OWNER_ID equals
                        owners.OWNER_ID
                        where breeds.BREED_ID == BREED_ID
                        group new { awards } by new { dogs.DOG_NAME, owners.OWNER_SURNAME,
                            owners.OWNER_NAME, owners.NUM_PHONE}  into g
                        select new QueryOneModel
                        {
                            DogName = g.Key.DOG_NAME,
                            Count = g.Count(),
                            Surname = g.Key.OWNER_SURNAME,
                            Name = g.Key.OWNER_NAME,
                            Phone = g.Key.NUM_PHONE
                            
                        };

            ViewBag.count = query.ToList();
            
            return PartialView(query.ToList());
        }
    }
}