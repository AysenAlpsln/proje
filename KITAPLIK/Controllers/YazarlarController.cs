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
    public class YazarlarController : Controller
    {
        private KıtapEntities3 db = new KıtapEntities3();

        // GET: Yazarlar
        public ActionResult Index(string ara)
        {
            var yazar = db.yazarlar;
            return View(yazar.Where(x => x.YazarAdSoyad.Contains(ara)||ara==null).ToList());
        }

        // GET: Yazarlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yazarlar yazarlar = db.yazarlar.Find(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        [Authorize(Roles = "A")]
        // GET: Yazarlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yazarlar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [Authorize(Roles = "A")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Yazarıd,YazarAdSoyad,dogum,olum,okul")] yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                db.yazarlar.Add(yazarlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yazarlar);
        }

        // GET: Yazarlar/Edit/5
        [Authorize(Roles = "A")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yazarlar yazarlar = db.yazarlar.Find(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // POST: Yazarlar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [Authorize(Roles = "A")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Yazarıd,YazarAdSoyad,dogum,olum,okul")] yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yazarlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yazarlar);
        }

        // GET: Yazarlar/Delete/5
        [Authorize(Roles = "A")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yazarlar yazarlar = db.yazarlar.Find(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // POST: Yazarlar/Delete/5
        [Authorize(Roles = "A")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yazarlar yazarlar = db.yazarlar.Find(id);
            db.yazarlar.Remove(yazarlar);
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
