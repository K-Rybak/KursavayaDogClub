using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;

namespace KursavayaDogClub.Controllers
{
    public class DogAwardsController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: DogAwards
        public ActionResult Index()
        {
            var dOG_AWARD = db.DOG_AWARD.Include(d => d.AWARD).Include(d => d.DOG);
            return View(dOG_AWARD.ToList());
        }

        // GET: DogAwards/Details/5
        public ActionResult Details(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG_AWARD dOG_AWARD = db.DOG_AWARD.Find(id);
            if (dOG_AWARD == null)
            {
                return HttpNotFound();
            }
            return View(dOG_AWARD);
        }

        // GET: DogAwards/Create
        public ActionResult Create()
        {
            ViewBag.AWARD_ID = new SelectList(db.AWARD, "AWARD_ID", "AWARD_NAME");
            ViewBag.DOG_ID = new SelectList(db.DOG, "DOG_ID", "DOG_NAME");
            return View();
        }

        // POST: DogAwards/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DOG_ID,AWARD_ID,DATE_AWARD")] DOG_AWARD dOG_AWARD)
        {
            if (ModelState.IsValid)
            {
                db.DOG_AWARD.Add(dOG_AWARD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AWARD_ID = new SelectList(db.AWARD, "AWARD_ID", "AWARD_NAME", dOG_AWARD.AWARD_ID);
            ViewBag.DOG_ID = new SelectList(db.DOG, "DOG_ID", "DOG_NAME", dOG_AWARD.DOG_ID);
            return View(dOG_AWARD);
        }

        // GET: DogAwards/Edit/5
        public ActionResult Edit(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG_AWARD dOG_AWARD = db.DOG_AWARD.Find(id);
            if (dOG_AWARD == null)
            {
                return HttpNotFound();
            }
            ViewBag.AWARD_ID = new SelectList(db.AWARD, "AWARD_ID", "AWARD_NAME", dOG_AWARD.AWARD_ID);
            ViewBag.DOG_ID = new SelectList(db.DOG, "DOG_ID", "DOG_NAME", dOG_AWARD.DOG_ID);
            return View(dOG_AWARD);
        }

        // POST: DogAwards/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRIMARY,DOG_ID,AWARD_ID,DATE_AWARD")] DOG_AWARD dOG_AWARD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOG_AWARD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AWARD_ID = new SelectList(db.AWARD, "AWARD_ID", "AWARD_NAME", dOG_AWARD.AWARD_ID);
            ViewBag.DOG_ID = new SelectList(db.DOG, "DOG_ID", "DOG_NAME", dOG_AWARD.DOG_ID);
            return View(dOG_AWARD);
        }

        // GET: DogAwards/Delete/5
        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG_AWARD dOG_AWARD = db.DOG_AWARD.Find(id);
            if (dOG_AWARD == null)
            {
                return HttpNotFound();
            }
            return View(dOG_AWARD);
        }

        // POST: DogAwards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DOG_AWARD dOG_AWARD = db.DOG_AWARD.Find(id);
            db.DOG_AWARD.Remove(dOG_AWARD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
