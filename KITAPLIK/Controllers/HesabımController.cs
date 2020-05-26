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
        KıtapEntities3 db = new KıtapEntities3();
        
        public ActionResult Hesabım()
        {
            return View();
        }
        
        
    }
}