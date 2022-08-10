using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : BaseController
    {
        // GET: Cari
        public ActionResult Index()
        {
            var model = db.Caris.Where(x=>x.Durum==true).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CariEkle() {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            db.Caris.Add(cari);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id) {
            var cari = db.Caris.Find(id);
            cari.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id) {
            var model = db.Caris.Find(id);
            return View("CariGetir", model);
        }

        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid) {
                return View("CariGetir");
            }
            var car = db.Caris.Find(cari.CariID);
            car.CariAd = cari.CariAd;
            car.CariSoyad = cari.CariSoyad;
            car.CariSehir = cari.CariSehir;
            car.CariMail = cari.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id) {            
            var deger = db.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = db.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.car = cari;
            return View(deger);
        }
    }
}