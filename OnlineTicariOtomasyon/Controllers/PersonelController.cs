using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : BaseController
    {
        // GET: Personel
        public ActionResult Index()
        {
            var model = db.Personels.ToList();
            return View(model);
        }

        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            db.Personels.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id) 
        {
            List<SelectListItem> deger1 = (from x in db.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dg1 = deger1;
            var personel = db.Personels.Find(id);
            return View("PersonelGetir",personel);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var prs = db.Personels.Find(personel.PersonelID);
            prs.PersonelAd = personel.PersonelAd;
            prs.PersonelSoyad = personel.PersonelSoyad;
            prs.PersonelGorsel = personel.PersonelGorsel;
            prs.DepartmanId = personel.DepartmanId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}