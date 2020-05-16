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
    public class YorumController : Controller
    {
        private data db = new data();

        // GET: Yorum
        public ActionResult Index()
        {
            var yorum = db.Yorum.Include(y => y.Kıtaplar).Include(y => y.Uyeler);
            return View(yorum.ToList());
        }

        // GET: Yorum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // GET: Yorum/Create
        public ActionResult Create()
        {
            ViewBag.kıtapıd = new SelectList(db.Kıtaplar, "kıtapıd", "kıtapadı");
            ViewBag.uyeıd = new SelectList(db.Uyeler, "Uyeıd", "takmaad");
            return View();
        }

        // POST: Yorum/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Yorumıd,yorum1,uyeıd,kıtapıd")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Yorum.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kıtapıd = new SelectList(db.Kıtaplar, "kıtapıd", "kıtapadı", yorum.kıtapıd);
            ViewBag.uyeıd = new SelectList(db.Uyeler, "Uyeıd", "takmaad", yorum.uyeıd);
            return View(yorum);
        }

        // GET: Yorum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.kıtapıd = new SelectList(db.Kıtaplar, "kıtapıd", "kıtapadı", yorum.kıtapıd);
            ViewBag.uyeıd = new SelectList(db.Uyeler, "Uyeıd", "takmaad", yorum.uyeıd);
            return View(yorum);
        }

        // POST: Yorum/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Yorumıd,yorum1,uyeıd,kıtapıd")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kıtapıd = new SelectList(db.Kıtaplar, "kıtapıd", "kıtapadı", yorum.kıtapıd);
            ViewBag.uyeıd = new SelectList(db.Uyeler, "Uyeıd", "takmaad", yorum.uyeıd);
            return View(yorum);
        }

        // GET: Yorum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // POST: Yorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum yorum = db.Yorum.Find(id);
            db.Yorum.Remove(yorum);
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
