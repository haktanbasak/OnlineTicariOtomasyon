using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : BaseController
    {
        // GET: UrunDetay
        public ActionResult Index()
        {
            //var model = db.Uruns.Where(x => x.UrunID == 1).ToList();
            Class1 cs = new Class1();
            cs.Deger1 = db.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Deger2 = db.Detays.Where(x => x.DetayID== 1).ToList();
            return View(cs);
        }
    }
}