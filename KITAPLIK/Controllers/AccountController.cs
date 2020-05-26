using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KITAPLIK.Models.Entity;

namespace KITAPLIK.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        KıtapEntities3 db = new KıtapEntities3();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Uyeler acc)
        {
            db.Uyeler.Add(acc);//yazılanları uyelere ekler
            db.SaveChanges();//veritabanında olan değişiklikleri kaydeder
            return View();

  
        }
        
        [HttpPost]
        public ActionResult Login(Uyeler t)
        {
            var bilgiler = db.Uyeler.FirstOrDefault(x => x.takmaad == t.takmaad && x.sıfre == t.sıfre);//yazılan parola ve kullanıcı adı kayıtlı ise
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.takmaad, false);
                return RedirectToAction("Anasayfa", "Anasayfa");//anasayfaya gönderir
            }
            else
            {
                return RedirectToAction("SignUp");//kayıt yok ise sayfa yenilenir
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignUp");
        }
        
    }
}