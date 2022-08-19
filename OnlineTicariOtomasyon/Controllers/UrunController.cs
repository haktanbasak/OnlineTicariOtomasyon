using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : BaseController
    {
        // GET: Urun
        public ActionResult Index(string p)
        {
            var model = from x in db.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                model = model.Where(y => y.UrunAd.Contains(p));
            }
            return View(model.ToList());
        }

        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            db.Uruns.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.Uruns.Find(id);
            urun.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urun = db.Uruns.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = db.Uruns.Find(urun.UrunID);
            urn.UrunAd = urun.UrunAd;
            urn.Marka = urun.Marka;
            urn.Stok = urun.Stok;
            urn.AlisFiyat = urun.AlisFiyat;
            urn.SatisFiyat = urun.SatisFiyat;
            urn.Durum = urun.Durum;
            urn.KategoriId = urun.KategoriId;
            urn.UrunGorsel = urun.UrunGorsel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = db.Uruns.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id) {
            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;
            var deger1 = db.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }

    }
}