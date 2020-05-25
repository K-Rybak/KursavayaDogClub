using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursavayaDogClub.Models;
using Oracle.ManagedDataAccess.Client;

namespace KursavayaDogClub.Controllers
{
    public class ArchiveController : Controller
    {
        DogDbContext db = new DogDbContext();
        // GET: Archive
        public ActionResult Index()
        {
            return View(db.DOG_ARCHIVE);
        }


        public ActionResult Table()
        {
            return View(db.DOG_ARCHIVE);
        }
        //запрос с использованием функции написанной в СУБД Oracle
        //переносит умерших собак в архивную таблицу, при условии что у них нет потомков
        public ActionResult GetDog()
        {
            var parametrs = new[]
            {
                new OracleParameter("p1", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,100,null,ParameterDirection.Output)
            };

            
            db.Database.ExecuteSqlCommand("BEGIN KINOLOGY_CLUB.COPYARCHIVE(:p1); END;", parametrs);
            ViewBag.Res = parametrs[0].Value;
      
            return PartialView();
        }
    }
}