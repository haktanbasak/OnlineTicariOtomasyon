using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : BaseController
    {
        // GET: Fatura
        public ActionResult Index()
        {
            var model = db.Faturas.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {            
            return View();
        }


        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            db.Faturas.Add(fatura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}