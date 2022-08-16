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

        public ActionResult FaturaGetir(int id)
        {
            var fatura = db.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            var fat = db.Faturas.Find(fatura.FaturaID);
            fat.FaturaSeriNo = fatura.FaturaSeriNo;
            fat.FaturaSiraNo = fatura.FaturaSiraNo;
            fat.VergiDairesi = fatura.VergiDairesi;
            fat.Tarih = fatura.Tarih;
            fat.Saat = fatura.Saat;
            fat.TeslimAlan = fatura.TeslimAlan;
            fat.TeslimEden = fatura.TeslimEden;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var deger = db.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            db.FaturaKalems.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}