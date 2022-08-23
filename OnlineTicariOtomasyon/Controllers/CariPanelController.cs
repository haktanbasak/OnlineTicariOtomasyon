using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : BaseController
    {
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = db.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = db.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var model = db.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(model);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var model = db.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelenSayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(model);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = db.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var model = db.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelenSayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var model = db.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelenSayisi = db.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = db.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidenSayisi;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            var mail = (string)Session["CariMail"];
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesaj.Gonderici = mail;
            db.Mesajlars.Add(mesaj);
            db.SaveChanges();
            return View();
        }
    }
}