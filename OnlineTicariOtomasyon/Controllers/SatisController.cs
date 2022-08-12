using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : BaseController
    {
        // GET: Satis
        public ActionResult Index()
        {
            var model = db.SatisHarekets.ToList();
            return View(model);
        }

        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in db.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in db.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in db.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in db.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger = db.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            var deger = db.SatisHarekets.Find(satis.SatisID);
            deger.CariId = satis.CariId;
            deger.UrunId = satis.UrunId;
            deger.PersonelId = satis.PersonelId;
            deger.Adet = satis.Adet;
            deger.Fiyat = satis.Fiyat;
            deger.ToplamTutar = satis.ToplamTutar;
            deger.Tarih = satis.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id) 
        {
            var deger = db.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(deger);
        }
    }
}