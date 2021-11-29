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

            //var degerler = db.TBLURUNLER.ToList();

            return View(/*degerler*/);
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

    }
}