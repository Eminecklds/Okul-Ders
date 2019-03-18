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
    public class OgrenciDersController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: OgrenciDers
        public ActionResult Index()
        {
            //ogretmen listesi aç ogrencidersten al
            //ders listesi aç öğretmenden al
            var ogrtmen = (from o in db.Ogretmens
                           join d in db.OgrenciDers
                           on o.OgretmenID equals d.DerID
                           select new
                           {
                               DersID=o.DersID,
                               OgrAd=o.Adi+" "+o.Soyadi
                           }).ToList();
            var ders = (from o in ogrtmen
                        join d in db.Derses
                        on o.DersID equals d.DersID
                        select new
                        {
                            DersAdi = d.DersAdi
                        }).ToList();
            ViewBag.ListeOgretmen  = new SelectList(ogrtmen.ToList(), "DerID", "DerOgr");
            ViewBag.ListeDers= new SelectList(ders.ToList(), "DersAdi");
          
          
            return View(db.OgrenciDers.ToList());
        }

        // GET: OgrenciDers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            if (ogrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciDers);
        }

        // GET: OgrenciDers/Create
        public ActionResult Create()
        {
            var liste = (from Ders in db.Derses
                         join Ogr in db.Ogretmens
                         on Ders.DersID equals Ogr.DersID
                         select new
                         {
                             DerID = Ogr.OgretmenID,
                             DerOgr = Ders.DersAdi + "-" + Ogr.Adi + " " + Ogr.Soyadi
                         }).ToList();

            ViewBag.DersListe = new SelectList(liste.ToList(), "DerID", "DerOgr");
            ViewBag.OgrenciID = new SelectList(db.Ogrencis, "OgrenciID", "Adi");

            return View();
        }

        // POST: OgrenciDers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( OgrenciDers ogrenciDers)
        {
            if (ModelState.IsValid)
            {
                var liste = (from Ders in db.Derses
                             join Ogr in db.Ogretmens
                             on Ders.DersID equals Ogr.DersID
                             where Ogr.OgretmenID==ogrenciDers.DerID
                             select new
                             {

                                 DerOgr = Ders.DersAdi + "-" + Ogr.Adi + " " + Ogr.Soyadi
                             }).FirstOrDefault();
                OgrenciDers ogr = new OgrenciDers();
                ogr.DerID = ogrenciDers.DerID;
                ogr.OgrenciID = ogrenciDers.OgrenciID;
                ogr.DerOgr = liste.DerOgr.ToString();
                db.OgrenciDers.Add(ogr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrenciID = new SelectList(db.Ogrencis, "OgrenciID", "Adi", ogrenciDers.OgrenciID);
           
            return View(ogrenciDers);
        }

        // GET: OgrenciDers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            if (ogrenciDers == null)
            {
                return HttpNotFound();
            }
            var liste = (from Ders in db.Derses
                         join Ogr in db.Ogretmens
                         on Ders.DersID equals Ogr.DersID
                         select new
                         {
                             DerID = Ogr.OgretmenID,
                             DerOgr = Ders.DersAdi + "-" + Ogr.Adi + " " + Ogr.Soyadi
                         }).ToList();

            ViewBag.DersListe = new SelectList(liste.ToList(), "DerID", "DerOgr");
            ViewBag.OgrenciID = new SelectList(db.Ogrencis, "OgrenciID", "Adi", ogrenciDers.OgrenciID);
          
            return View(ogrenciDers);
        }

        // POST: OgrenciDers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OgrenciID,DerID")] OgrenciDers ogrenciDers)
        {
            if (ModelState.IsValid)
            {
                var liste2 = (from Ders in db.Derses
                             join Ogr in db.Ogretmens
                             on Ders.DersID equals Ogr.DersID
                             where Ogr.OgretmenID == ogrenciDers.DerID
                             select new
                             {

                                 DerOgr = Ders.DersAdi + "-" + Ogr.Adi + " " + Ogr.Soyadi
                             }).FirstOrDefault();
                ogrenciDers.DerOgr = liste2.DerOgr.ToString();
                OgrenciDers ogr = new OgrenciDers();
                ogr.ID = ogrenciDers.ID;
                ogr.OgrenciID = ogrenciDers.OgrenciID;
                ogr.DerID = ogrenciDers.DerID;
                ogr.DerOgr =liste2.DerOgr.ToString();
                db.Entry(ogrenciDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var liste = (from Ders in db.Derses
                         join Ogr in db.Ogretmens
                         on Ders.DersID equals Ogr.DersID
                         select new
                         {
                             DerID = Ogr.OgretmenID,
                             DerOgr = Ders.DersAdi + "-" + Ogr.Adi + " " + Ogr.Soyadi
                         }).ToList();

            ViewBag.DersListe = new SelectList(liste.ToList(), "DerID", "DerOgr");
            ViewBag.OgrenciID = new SelectList(db.Ogrencis, "OgrenciID", "Adi", ogrenciDers.OgrenciID);
           
            return View(ogrenciDers);
        }

        // GET: OgrenciDers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            if (ogrenciDers == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciDers);
        }

        // POST: OgrenciDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrenciDers ogrenciDers = db.OgrenciDers.Find(id);
            db.OgrenciDers.Remove(ogrenciDers);
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
