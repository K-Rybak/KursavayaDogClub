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
    public class StreetsController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: Streets
        public ActionResult Index()
        {
            return View(db.STREET.ToList());
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STREET sTREET = db.STREET.Find(id);
            if (sTREET == null)
            {
                return HttpNotFound();
            }
            return View(sTREET);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Streets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STREET_NAME")] STREET sTREET)
        {
            if (ModelState.IsValid)
            {
                db.STREET.Add(sTREET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTREET);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STREET sTREET = db.STREET.Find(id);
            if (sTREET == null)
            {
                return HttpNotFound();
            }
            return View(sTREET);
        }

        // POST: Streets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STREET_ID,STREET_NAME")] STREET sTREET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTREET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTREET);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STREET sTREET = db.STREET.Find(id);
            if (sTREET == null)
            {
                return HttpNotFound();
            }
            return View(sTREET);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STREET sTREET = db.STREET.Find(id);
            db.STREET.Remove(sTREET);
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
