using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KITAPLIK.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace KITAPLIK.Controllers
{
    public class KıtaplarController : Controller
    {
        private KıtapEntities3 db = new KıtapEntities3();

        // GET: Kıtaplar
        public ActionResult Index(string ara)
        {
            var kıtaplar = db.Kıtaplar.Include(k => k.KıtapDetay).Include(k => k.Kutuphanem);
            return View(kıtaplar.Where(x => x.kıtapadı.Contains(ara)||ara==null).ToList());
            //var degerler = db.Kıtaplar.Include(k => k.KıtapDetay).Include(k => k.Kutuphanem).ToList().ToPagedList(sayfa,10);
            //return View(degerler.Where(x => x.kıtapadı.Contains(ara) || ara == null).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kıtaplar kıtaplar = db.Kıtaplar.Find(id);
            if (kıtaplar == null)
            {
                return HttpNotFound();
            }
            return View(kıtaplar);
        }

        [Authorize(Roles ="A")]
        // GET: Kıtaplar/Create
        public ActionResult Create()
        {
            ViewBag.kıtapıd = new SelectList(db.KıtapDetay, "kıtapıd", "kıtapcevırmenı");
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd");
            return View();
        }

        // POST: Kıtaplar/Create
        [Authorize(Roles = "A")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kıtapıd,kıtapadı,acıklama,kıtapresım,cokokunanlar,edıtorunsectıklerı,Anasayfa,Surukleyıcıyenılerıcın")] Kıtaplar kıtaplar)
        {
            if (ModelState.IsValid)
            {
                db.Kıtaplar.Add(kıtaplar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kıtapıd = new SelectList(db.KıtapDetay, "kıtapıd", "kıtapcevırmenı", kıtaplar.kıtapıd);
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            return View(kıtaplar);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kıtaplar kıtaplar = db.Kıtaplar.Find(id);
            if (kıtaplar == null)
            {
                return HttpNotFound();
            }
            ViewBag.kıtapıd = new SelectList(db.KıtapDetay, "kıtapıd", "kıtapcevırmenı", kıtaplar.kıtapıd);
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            return View(kıtaplar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kıtapıd,kıtapadı,acıklama,kıtapresım,cokokunanlar")] Kıtaplar kıtaplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kıtaplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kıtapıd = new SelectList(db.KıtapDetay, "kıtapıd", "kıtapcevırmenı", kıtaplar.kıtapıd);
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            return View(kıtaplar);
        }


        // GET: Kıtaplar/Delete/5
        [Authorize(Roles = "A")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kıtaplar kıtaplar = db.Kıtaplar.Find(id);
            if (kıtaplar == null)
            {
                return HttpNotFound();
            }
            return View(kıtaplar);
        }

        // POST: Kıtaplar/Delete/5
        [Authorize(Roles = "A")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kıtaplar kıtaplar = db.Kıtaplar.Find(id);
            db.Kıtaplar.Remove(kıtaplar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
