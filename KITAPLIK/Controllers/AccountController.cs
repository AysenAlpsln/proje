﻿using System;
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

            var bilgi = db.tbl_account.FirstOrDefault(x => x.userName == acc.userName && x.password == acc.password);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.userName, false);
                return RedirectToAction("AnaSayfa", "AnaSayfa");
            }
            else
            {
                return View();
            }
        }
        
    }
}