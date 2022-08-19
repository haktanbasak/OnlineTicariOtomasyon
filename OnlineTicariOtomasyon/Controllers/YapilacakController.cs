using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : BaseController
    {
        // GET: Yapilacak
        public ActionResult Index()
        {
            var deger1 = db.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = db.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = db.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in db.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            var yapilacak = db.Yapilacaks.ToList();
            return View(yapilacak);
        }
    }
}