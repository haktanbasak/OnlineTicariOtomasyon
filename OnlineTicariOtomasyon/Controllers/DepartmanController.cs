using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : BaseController
    {
        // GET: Departman
        public ActionResult Index()
        {
            var model = db.Departmans.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult DepartmanEkle() {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            db.Departmans.Add(departman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id) {
            var departman = db.Departmans.Find(id);
            departman.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id) {
            var dep = db.Departmans.Find(id);
            return View("DepartmanGetir", dep);
        }

        public ActionResult DepartmanGuncelle(Departman departman) {
            var dep = db.Departmans.Find(departman.DepartmanID);
            dep.DepartmanAd = departman.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id) {
            var degerler = db.Personels.Where(x => x.PersonelID == id).ToList();
            var dpt = db.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dep = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id) {
            var deger = db.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var per = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.pers = per;
            return View(deger);
        }
    }
}