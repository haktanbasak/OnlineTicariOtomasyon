using OnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : BaseController
    {
        // GET: Kategori
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            db.Kategoris.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kate = db.Kategoris.Find(id);
            db.Kategoris.Remove(kate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktg = db.Kategoris.Find(kategori.KategoriID);
            ktg.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}