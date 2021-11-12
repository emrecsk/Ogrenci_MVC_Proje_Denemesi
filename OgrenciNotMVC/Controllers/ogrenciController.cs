using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class ogrenciController : Controller
    {
        // GET: ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var std = db.TBLOGRENCILER.ToList();
            return View(std);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ogrGetir(int id)
        {
            var glnogrenci = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("ogrGetir", glnogrenci);
        }

        public ActionResult Guncelle (TBLOGRENCILER p)
        {
            var ogrgln = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogrgln.OGRAD = p.OGRAD;
            ogrgln.OGRSOYAD = p.OGRSOYAD;
            ogrgln.OGRFOTO = p.OGRFOTO;
            ogrgln.OGRCINSIYET = p.OGRCINSIYET;
            ogrgln.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "ogrenci");
        }
    }

    //List<SelectListItem> items = new List<SelectListItem>();

    //items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

    //items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

    //items.Add(new SelectListItem { Text = "Atatürk ilke ve inkilapları", Value = "2" });

    //items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });

    //items.Add(new SelectListItem { Text = "Edebiyat", Value = "4" });

    //ViewBag.DersAd = items;
}