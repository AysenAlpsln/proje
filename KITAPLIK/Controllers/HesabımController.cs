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
        public ActionResult KullanıcıGetir(int id)
        {
            var kul = db.Uyeler.Find(id);
            return View("Hesabım", kul);
        }
    }
}