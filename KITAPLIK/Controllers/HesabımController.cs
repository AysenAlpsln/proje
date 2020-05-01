using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KITAPLIK.Models.Entity;

namespace KITAPLIK.Controllers
{
    public class HesabımController : Controller
    {
        // GET: Hesabım
        KıtapEntities1 db = new KıtapEntities1();
        
        public ActionResult Hesabım()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProfilGetir(int id)
        {
            var uye = db.Uyeler.Find(id);
            return View("ProfilGetir", uye);
        }
        public ActionResult ProfilDüzenle(Uyeler u)
        {
            var uye = db.Uyeler.Find(u.Uyeıd);
            uye.AdSoyad = u.AdSoyad;
            uye.DogumYeri = u.DogumYeri;
            uye.DogumTarıhı = u.DogumTarıhı;
            uye.Cınsıyet = u.Cınsıyet;
            uye.Meslegi = u.Meslegi;
            uye.YasadıgıSehir = u.YasadıgıSehir;
            uye.Biografi = u.Biografi;
            db.SaveChanges();
            return RedirectToAction("Hesabım");
        }
        public ActionResult Detay(int id)
        {
            var uye = db.Uyeler.Find(id);
            ViewData["ad"] = uye.AdSoyad;
            return View();
        }        
        
        
    }
}