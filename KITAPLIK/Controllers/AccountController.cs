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
        data db = new data();
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
            db.Uyeler.Add(acc);
            db.SaveChanges();
            return View();

  
        }
        [HttpPost]
        public ActionResult Login(Uyeler t)
        {
            var bilgiler = db.Uyeler.FirstOrDefault(x => x.takmaad == t.takmaad && x.sıfre == t.sıfre);
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.takmaad, false);
                return RedirectToAction("Anasayfa", "Anasayfa");
            }
            else
            {
                ModelState.AddModelError(key: "", errorMessage: "Kullanıcı adı veya şifre hatalı");
                return View();
            }
        }
        
    }
}