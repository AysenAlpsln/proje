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
        KITAPLIKEntities1 db = new KITAPLIKEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SingUp(tbl_account acc)
        {
            db.tbl_account.Add(acc);
            db.SaveChanges();
            return View();

  
        }
        [HttpPost]
        public ActionResult Login(tbl_account t)
        {
            var bilgiler = db.tbl_account.FirstOrDefault(x => x.userName == t.userName && x.password == t.password);
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.userName, false);
                return RedirectToAction("Anasayfa", "Anasayfa");
            }
            else
            {
                return View();
            }
        }
        
    }
}