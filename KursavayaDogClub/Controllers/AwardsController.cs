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
    public class AwardsController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: Awards
        public ActionResult Index()
        {
            return View(db.AWARD.ToList());
        }

        // GET: Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AWARD aWARD = db.AWARD.Find(id);
            if (aWARD == null)
            {
                return HttpNotFound();
            }
            return View(aWARD);
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Awards/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AWARD_ID,AWARD_NAME")] AWARD aWARD)
        {
            if (ModelState.IsValid)
            {
                db.AWARD.Add(aWARD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aWARD);
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AWARD aWARD = db.AWARD.Find(id);
            if (aWARD == null)
            {
                return HttpNotFound();
            }
            return View(aWARD);
        }

        // POST: Awards/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AWARD_ID,AWARD_NAME")] AWARD aWARD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aWARD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aWARD);
        }

        // GET: Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AWARD aWARD = db.AWARD.Find(id);
            if (aWARD == null)
            {
                return HttpNotFound();
            }
            return View(aWARD);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AWARD aWARD = db.AWARD.Find(id);
            db.AWARD.Remove(aWARD);
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
