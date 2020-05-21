using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KITAPLIK.Models.Entity;

namespace KITAPLIK.Controllers
{
    public class AyarlarController : Controller
    {
        KıtapEntities3 db = new KıtapEntities3();
        // GET: Ayarlar
        public ActionResult Ayarlar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Düzenle(Uyeler k)
        {
            var uye = db.Uyeler.Find(k.takmaad);
            uye.AdSoyad = k.AdSoyad;
            uye.Cınsıyet = k.Cınsıyet;
            uye.DogumYeri = k.DogumYeri;
            uye.DogumTarıhı = k.DogumTarıhı;
            uye.Telefon = k.Telefon;
            uye.Meslegi = k.Meslegi;
            uye.Biografi = k.Biografi;
            db.SaveChanges();
            return RedirectToAction("Hesabım", "Hesabım");
        }
    }
}