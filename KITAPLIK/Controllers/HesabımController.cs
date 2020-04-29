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

        public ActionResult Hesabım(int id)
        {
            return View();
        }
        public ActionResult Bilgi(int id)
        {
            var bilgiler = db.Uyeler.Find(id);
            if (bilgiler != null)
            {
                return View(db.Uyeler.Where(m => m.Uyeıd == id).ToList());
            }
            return View();
        }
        
        
    }
}