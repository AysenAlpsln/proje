using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KITAPLIK.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}