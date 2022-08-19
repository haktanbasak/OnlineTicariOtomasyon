using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : BaseController
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            var toplamCari = db.Caris.Count().ToString();
            ViewBag.d1 = toplamCari;

            var toplamUrun = db.Uruns.Count().ToString();
            ViewBag.d2 = toplamUrun;

            var toplamPersonel = db.Personels.Count().ToString();
            ViewBag.d3 = toplamPersonel;

            var toplamKategori = db.Kategoris.Count().ToString();
            ViewBag.d4 = toplamKategori;

            var toplamStok = db.Uruns.Sum(x => x.Stok);
            ViewBag.d5 = toplamStok;

            var toplamMarka = (from x in db.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = toplamMarka;

            var kritikSeviye = db.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = kritikSeviye;

            var maxFiyatUrun = (from x in db.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = maxFiyatUrun;

            var minFiyatUrun = (from x in db.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = minFiyatUrun;

            var buzdolabiSayi = db.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = buzdolabiSayi;

            var laptopSayi = db.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = laptopSayi;

            var maxMarka = db.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = maxMarka;

            var enCokSatan = db.Uruns.Where(u => u.UrunID == (db.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = enCokSatan;

            var kasadakiTutar = db.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = kasadakiTutar;

            DateTime bugun = DateTime.Today;
            var bugunkiSatis = db.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = bugunkiSatis;

            var bugunkiKasa = db.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = bugunkiKasa;
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in db.Caris
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in db.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = db.Caris.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = db.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in db.Uruns
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            marka = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }
    }
}