using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcDers.Models;

namespace MvcDers.Controllers
{
    public class OgrencisController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: Ogrencis
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrencis.Include(e => e.Sinif);
            return View(ogrenciler.ToList());
        }

        public ActionResult _DersListele(int id)
        {
            var result = (from d in db.Ogrencis
                          join og in db.OgrenciDers 
                          on d.OgrenciID equals og.OgrenciID
                          where d.OgrenciID==id
                          select new
                          {
                              og.DerOgr
                          }
                ).ToList();

                return PartialView(result);
        }

        // GET: Ogrencis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.SinifID = new SelectList(db.Sinifs, "SinifID", "Sinifi",ogrenci.SinifID);
            return View(ogrenci);
        }

        // GET: Ogrencis/Create
        public ActionResult Create()
        {
            ViewBag.Sinif = new SelectList(db.Sinifs.ToList(), "SinifID", "SinifAdi");
            return View();
        }

        // POST: Ogrencis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
 
        public ActionResult Create(OgrenciSinifViewModel ogrenci)
        {
            if (ModelState.IsValid)
            {
                Ogrenci ogr = new Ogrenci();
                ogr.Adi = ogrenci.Adi;
                ogr.Soyadi = ogrenci.Soyadi;
                ogr.OkulNo = ogrenci.OkulNo;
                ViewBag.SinifID = ogrenci.SinifID;
                ogr.SinifID = ViewBag.SinifID;
                db.Ogrencis.Add(ogr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenci);
        }

        // GET: Ogrencis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.SinifID = new SelectList(db.Sinifs, "SinifID", "SinifAdi", ogrenci.SinifID);
            return View(ogrenci);
        }

        // POST: Ogrencis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciID,OkulNo,Adi,Soyadi,SinifID")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SinifID = new SelectList(db.Sinifs, "SinifID", "SinifAdi", ogrenci.SinifID);
            return View(ogrenci);
        }

        // GET: Ogrencis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.SinifID = new SelectList(db.Sinifs, "SinifID", "Sinifi", ogrenci.SinifID);
            return View(ogrenci);
        }

        // POST: Ogrencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.Ogrencis.Find(id);
            db.Ogrencis.Remove(ogrenci);
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
