using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KITAPLIK.Controllers
{
    [Authorize]
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}