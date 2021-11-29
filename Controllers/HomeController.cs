using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FahharTest.Models.Entity;

namespace FahharTest.Controllers
{
    public class HomeController : Controller
    {
        DBFAHHAREntities1 db = new DBFAHHAREntities1();
        public ActionResult Index()
        {
            var urun = db.TBLURUNLER.ToList();
            return View(urun);
        }
        
        [HttpGet]

        public ActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UrunEkle(TBLURUNLER k)
        {
            if (!ModelState.IsValid)
            {
                return View("UrunEkle");
            }
            var indirim =((k.FIYAT * k.INDIRIM) / 100);
            var sepetfiyat = k.FIYAT -indirim;
            k.SEPETFIYAT = sepetfiyat;

            db.TBLURUNLER.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunIslem()
        {
            var urun = db.TBLURUNLER.ToList();
            return View(urun);
        }
        public ActionResult UrunGetir(int id)
        {

            var urun = db.TBLURUNLER.Find(id);

            return View("UrunGetir",urun);
        }
        public ActionResult UrunDuzenle(TBLURUNLER k)
        {
            var urun = db.TBLURUNLER.Find(k.ID);
            urun.ADI = k.ADI;
            urun.ACIKLAMA = k.ACIKLAMA;
            urun.FIYAT = k.FIYAT;
            urun.INDIRIM = k.INDIRIM;
            urun.RESIM = k.RESIM;
            var indirim = ((k.FIYAT * k.INDIRIM) / 100);
            var sepetfiyat = k.FIYAT - indirim;
            k.SEPETFIYAT = sepetfiyat;
            urun.SEPETFIYAT = k.SEPETFIYAT;
            urun.ISKARGO = k.ISKARGO;
            db.SaveChanges(); 
            return RedirectToAction("UrunIslem");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("UrunIslem");
        }
    }
}