using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KITAPLIK.Models.Entity;

namespace KITAPLIK.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        KITAPLIKEntities1 db = new KITAPLIKEntities1();

        [Authorize]
        public ActionResult AnaSayfa()
        {
            return View();
        }
    }
}