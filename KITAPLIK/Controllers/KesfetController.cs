using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KITAPLIK.Controllers
{
    public class KesfetController : Controller
    {
        [Authorize(Roles ="A,U")]
        // GET: Kesfet
        public ActionResult Index()
        {
            return View();
        }
    }
}