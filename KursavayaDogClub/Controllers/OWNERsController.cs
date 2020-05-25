using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;
using Oracle.ManagedDataAccess.Client;

namespace KursavayaDogClub.Controllers
{
    public class OWNERsController : Controller
    {
        private DogDbContext db = new DogDbContext();

        // GET: OWNERs
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return Redirect("/");

            var oWNER = db.OWNER.Include(o => o.DISTRICT).Include(o => o.STREET);
            return View(oWNER.ToList());
        }

        public ActionResult GetNumber(string number)
        {
            var parametrs = new[]
            {
                new OracleParameter("p1", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2)
            };

            parametrs[0].Value = number;
            var formatNumber = db.Database.SqlQuery<String>("SELECT KINOLOGY_CLUB.FORMAT_NUMBER(:p1) FROM DUAL", parametrs);
            ViewBag.Number = formatNumber.ElementAt(0);
            return PartialView();
        }
        // GET: OWNERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OWNER oWNER = db.OWNER.Find(id);
            if (oWNER == null)
            {
                return HttpNotFound();
            }
            return View(oWNER);
        }

        // GET: OWNERs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DISTRICT = new SelectList(db.DISTRICT, "DISTRICT_ID", "DISTRICT_NAME");
            ViewBag.ID_STREET = new SelectList(db.STREET, "STREET_ID", "STREET_NAME");
            return View();
        }

        // POST: OWNERs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OWNER_SURNAME,OWNER_NAME,OWNER_PATRONYMIC,ID_DISTRICT,ID_STREET,NUM_HOUSE,NUM_APARTMENT,NUM_PHONE")] OWNER oWNER)
        {
            if (ModelState.IsValid)
            {
                db.OWNER.Add(oWNER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DISTRICT = new SelectList(db.DISTRICT, "DISTRICT_ID", "DISTRICT_NAME", oWNER.ID_DISTRICT);
            ViewBag.ID_STREET = new SelectList(db.STREET, "STREET_ID", "STREET_NAME", oWNER.ID_STREET);
            return View(oWNER);
        }

        // GET: OWNERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OWNER oWNER = db.OWNER.Find(id);
            if (oWNER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DISTRICT = new SelectList(db.DISTRICT, "DISTRICT_ID", "DISTRICT_NAME", oWNER.ID_DISTRICT);
            ViewBag.ID_STREET = new SelectList(db.STREET, "STREET_ID", "STREET_NAME", oWNER.ID_STREET);
            return View(oWNER);
        }

        // POST: OWNERs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OWNER_ID,OWNER_SURNAME,OWNER_NAME,OWNER_PATRONYMIC,ID_DISTRICT,ID_STREET,NUM_HOUSE,NUM_APARTMENT,NUM_PHONE")] OWNER oWNER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oWNER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DISTRICT = new SelectList(db.DISTRICT, "DISTRICT_ID", "DISTRICT_NAME", oWNER.ID_DISTRICT);
            ViewBag.ID_STREET = new SelectList(db.STREET, "STREET_ID", "STREET_NAME", oWNER.ID_STREET);
            return View(oWNER);
        }

        // GET: OWNERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OWNER oWNER = db.OWNER.Find(id);
            if (oWNER == null)
            {
                return HttpNotFound();
            }
            return View(oWNER);
        }

        // POST: OWNERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OWNER oWNER = db.OWNER.Find(id);
            db.OWNER.Remove(oWNER);
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

