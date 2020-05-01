using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KITAPLIK.Models.Entity;

namespace KITAPLIK.Controllers
{
    public class KıtaplarController : Controller
    {
        private KıtapEntities1 db = new KıtapEntities1();

        // GET: Kıtaplar
        public ActionResult Index()
        {
            var kıtaplar = db.Kıtaplar.Include(k => k.KıtapDetay).Include(k => k.Kutuphanem).Include(k => k.Kutuphanem1);
            return View(kıtaplar.ToList());
        }

        // GET: Kıtaplar/Details/5
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

        // GET: Kıtaplar/Create
        public ActionResult Create()
        {
            ViewBag.kıtapıd = new SelectList(db.KıtapDetay, "kıtapıd", "kıtapcevırmenı");
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd");
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd");
            return View();
        }

        // POST: Kıtaplar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
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
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            return View(kıtaplar);
        }

        // GET: Kıtaplar/Edit/5
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
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            return View(kıtaplar);
        }

        // POST: Kıtaplar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kıtapıd,kıtapadı,acıklama,kıtapresım,cokokunanlar,edıtorunsectıklerı,Anasayfa,Surukleyıcıyenılerıcın")] Kıtaplar kıtaplar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kıtaplar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kıtapıd = new SelectList(db.KıtapDetay, "kıtapıd", "kıtapcevırmenı", kıtaplar.kıtapıd);
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            ViewBag.kıtapıd = new SelectList(db.Kutuphanem, "kıtapıd", "kıtapıd", kıtaplar.kıtapıd);
            return View(kıtaplar);
        }

        // GET: Kıtaplar/Delete/5
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
