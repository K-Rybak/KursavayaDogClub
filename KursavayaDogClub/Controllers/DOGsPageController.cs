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
    public class DOGsPageController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: DOGsPage
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return Redirect("/");

            var dOG = db.DOG.Include(d => d.BREED).Include(d => d.OWNER);
            
            return View(dOG.ToList());
        }

        // GET: DOGsPage/Details/5
        public ActionResult Details(int? id)
        {

            if (Session["user"] == null)
                return Redirect("/");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG dOG = db.DOG.Find(id);
            if (dOG == null)
            {
                return HttpNotFound();
            }
            return View(dOG);
        }

        // GET: DOGsPage/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
                return Redirect("/");

            ViewBag.ID_BREED = new SelectList(db.BREED, "BREED_ID", "BREED_NAME");
            ViewBag.OWNER_ID = new SelectList(db.OWNER, "OWNER_ID", "OWNER_SURNAME");
            return View();
        }

        // POST: DOGsPage/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DOG_NAME,OWNER_ID,BIRTH_DATE,DEATH_DATE,SEX,ID_FATHER,ID_MOTHER,ID_BREED")] DOG dOG)
        {
            if (ModelState.IsValid)
            {
                db.DOG.Add(dOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BREED = new SelectList(db.BREED, "BREED_ID", "BREED_NAME", dOG.ID_BREED);
            ViewBag.OWNER_ID = new SelectList(db.OWNER, "OWNER_ID", "OWNER_SURNAME", dOG.OWNER_ID);
            return View(dOG);
        }

        // GET: DOGsPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["user"] == null)
                return Redirect("/");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG dOG = db.DOG.Find(id);
            if (dOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BREED = new SelectList(db.BREED, "BREED_ID", "BREED_NAME", dOG.ID_BREED);
            ViewBag.OWNER_ID = new SelectList(db.OWNER, "OWNER_ID", "OWNER_SURNAME", dOG.OWNER_ID);
            return View(dOG);
        }

        // POST: DOGsPage/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DOG_ID,DOG_NAME,OWNER_ID,BIRTH_DATE,DEATH_DATE,SEX,ID_FATHER,ID_MOTHER,ID_BREED")] DOG dOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BREED = new SelectList(db.BREED, "BREED_ID", "BREED_NAME", dOG.ID_BREED);
            ViewBag.OWNER_ID = new SelectList(db.OWNER, "OWNER_ID", "OWNER_SURNAME", dOG.OWNER_ID);
            return View(dOG);
        }

        // GET: DOGsPage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOG dOG = db.DOG.Find(id);
            if (dOG == null)
            {
                return HttpNotFound();
            }
            return View(dOG);
        }

        // POST: DOGsPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOG dOG = db.DOG.Find(id);
            db.DOG.Remove(dOG);
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
