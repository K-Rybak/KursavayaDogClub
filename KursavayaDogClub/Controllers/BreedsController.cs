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
    public class BreedsController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: Breeds
        public ActionResult Index()
        {
            return View(db.BREED.ToList());
        }

        // GET: Breeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BREED bREED = db.BREED.Find(id);
            if (bREED == null)
            {
                return HttpNotFound();
            }
            return View(bREED);
        }

        // GET: Breeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breeds/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BREED_NAME")] BREED bREED)
        {
            if (ModelState.IsValid)
            {
                db.BREED.Add(bREED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bREED);
        }

        // GET: Breeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BREED bREED = db.BREED.Find(id);
            if (bREED == null)
            {
                return HttpNotFound();
            }
            return View(bREED);
        }

        // POST: Breeds/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BREED_NAME")] BREED bREED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bREED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bREED);
        }

        // GET: Breeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BREED bREED = db.BREED.Find(id);
            if (bREED == null)
            {
                return HttpNotFound();
            }
            return View(bREED);
        }

        // POST: Breeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BREED bREED = db.BREED.Find(id);
            db.BREED.Remove(bREED);
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
