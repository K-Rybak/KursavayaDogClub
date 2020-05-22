using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

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
            ViewBag.ID_BREED = new SelectList(db.BREED, "BREED_ID", "BREED_NAME");
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


        [HttpPost]
        public void CreateDocument()
        {

            var query = from dogs in db.DOG
                        join dog_awards in db.DOG_AWARD on dogs.DOG_ID
                        equals dog_awards.DOG_ID
                        join award in db.AWARD on dog_awards.AWARD_ID
                        equals award.AWARD_ID
                        join breeds in db.BREED on dogs.ID_BREED
                        equals breeds.BREED_ID
                        
                        group new { dogs, dog_awards, award, breeds }
                        by new
                        {
                            breeds.BREED_NAME,
                            dogs.DOG_NAME,
                            dogs.SEX,
                            dogs.BIRTH_DATE,
                            award.AWARD_NAME,
                            dog_awards.DATE_AWARD
                        } into g
                        orderby g.Key.BREED_NAME, g.Key.DOG_NAME
                        select new
                        {
                            All = g.Key,
                            //Age = DateTime.Now.Subtract(Convert.ToDateTime(g.Key.BIRTH_DATE))
                        };



            WordDocument document = new WordDocument();
            
                List<string> list = new List<string>();
                List<string> breedsDog = new List<string>();
                document.EnsureMinimal();
                IWSection section = document.AddSection() as WSection;
                //Set Margin of the section
                section.PageSetup.Margins.All = 72;
                //Set page size of the section
                section.PageSetup.PageSize = new System.Drawing.SizeF(612, 792);
                //Create Paragraph styles
            
                IWParagraph paragraph = section.AddParagraph();

  

                foreach (var el in query.ToList())
                {
                    if (!breedsDog.Contains(el.All.BREED_NAME))
                    {
                        IWTextRange textRangeBreed = paragraph.AppendText(el.All.BREED_NAME + "\t\t\t\t\t"
                            + DateTime.Now.ToShortDateString() + "\n");

                        textRangeBreed.CharacterFormat.Bold = true;
                        textRangeBreed.CharacterFormat.FontName = "Times New Roman";
                        textRangeBreed.CharacterFormat.FontSize = 14;
                    breedsDog.Add(el.All.BREED_NAME);
                    }
                    if (!list.Contains(el.All.DOG_NAME))
                    {
                                             
                        IWTextRange textRange = paragraph.AppendText("Кличка: " + el.All.DOG_NAME
                            + " пол: " + el.All.SEX + " возраст: " + Convert.ToDateTime(el.All.BIRTH_DATE).ToShortDateString()
                            + " [награда: " + el.All.AWARD_NAME + " дата: " 
                            + Convert.ToDateTime(el.All.DATE_AWARD).ToShortDateString() + "]" + "\n");
                        
                        list.Add(el.All.DOG_NAME);
                        
                    }
                    else
                    {
                        document.LastParagraph.AppendText("\t\t\t\t\t\t[награда: " + el.All.AWARD_NAME + " дата: "
                            + Convert.ToDateTime(el.All.DATE_AWARD).ToShortDateString() + "]" + "\n");
                    }
                    

                }
                document.Save("Result.docx", FormatType.Docx, HttpContext.ApplicationInstance.Response, HttpContentDisposition.Attachment);
            

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
