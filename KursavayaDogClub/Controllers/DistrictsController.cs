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
    public class DistrictsController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: Districts
        public ActionResult Index()
        {
            return View(db.DISTRICT.ToList());
        }

        // GET: Districts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRICT dISTRICT = db.DISTRICT.Find(id);
            if (dISTRICT == null)
            {
                return HttpNotFound();
            }
            return View(dISTRICT);
        }

        // GET: Districts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Districts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DISTRICT_NAME")] DISTRICT dISTRICT)
        {
            if (ModelState.IsValid)
            {
                db.DISTRICT.Add(dISTRICT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dISTRICT);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRICT dISTRICT = db.DISTRICT.Find(id);
            if (dISTRICT == null)
            {
                return HttpNotFound();
            }
            return View(dISTRICT);
        }

        // POST: Districts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DISTRICT_NAME")] DISTRICT dISTRICT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISTRICT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dISTRICT);
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRICT dISTRICT = db.DISTRICT.Find(id);
            if (dISTRICT == null)
            {
                return HttpNotFound();
            }
            return View(dISTRICT);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISTRICT dISTRICT = db.DISTRICT.Find(id);
            db.DISTRICT.Remove(dISTRICT);
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
