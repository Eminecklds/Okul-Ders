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
    public class OgretmenController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: Ogretmen
        public ActionResult Index()
        {
            var ogretmeler = db.Ogretmens.Include(e => e.Ders);
            return View(ogretmeler.ToList());
        }
        public ActionResult PartialEgitmen()
        {
            return View(db.Derses.ToList());
        }

        public ActionResult _OgrenciListele(int id)
        {
            var result = (from a in db.Ogrencis
                          join b in db.OgrenciDers on a.OgrenciID equals b.OgrenciID
                          where b.DerID == id
                          select a).ToList();
            return PartialView(result);
        }
        public ActionResult OgretmenEkle()
        {
            if (ViewBag.Liste==null)
            ViewBag.Liste = new SelectList(db.Derses.ToList(), "DersID", "DersAdi");
            return View();
        }
        [HttpPost]
        public ActionResult OgretmenEkle(DersOgretmenViewModel ogretmen)
        {
            Ogretmen ogr = new Ogretmen();

            ogr.Adi = ogretmen.Adi;
            ogr.Soyadi = ogretmen.Soyadi;
            ogr.Bransi = ogretmen.Bransi;
            ViewBag.DersID =ogretmen.DersID;



            if (ViewBag.DersID!=0 && ViewBag.DersID!=null)
            {
ogr.DersID =ViewBag.DersID;
       
            db.Ogretmens.Add(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                
                return RedirectToAction("Index", "Ogretmen");
            }
            
        }

        // GET: Ogretmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = db.Ogretmens.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            ViewBag.DersID = new SelectList(db.Derses, "DersID", "DersAdi", ogretmen.DersID);
            return View(ogretmen);
        }

        // GET: Ogretmen/Create
   

        // GET: Ogretmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = db.Ogretmens.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            ViewBag.DersID = new SelectList(db.Derses, "DersID", "DersAdi", ogretmen.DersID);
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgretmenID,Adi,Soyadi,Bransi,DersID")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DersID = new SelectList(db.Derses, "DersID", "DersAdi", ogretmen.DersID);
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = db.Ogretmens.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogretmen ogretmen = db.Ogretmens.Find(id);
            db.Ogretmens.Remove(ogretmen);
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
