﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IShop;

namespace IShop.Areas.Administration.Controllers
{
    public class CategorieController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Categorie
        public ActionResult Index()
        {
            return View(db.CATEGORIE.ToList());
        }

        // GET: Administration/Categorie/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIE.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // GET: Administration/Categorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Categorie/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CATEGORIE,LIBELLE_CATEGORIE")] CATEGORIE cATEGORIE)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIE.Add(cATEGORIE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIE);
        }

        // GET: Administration/Categorie/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIE.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // POST: Administration/Categorie/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CATEGORIE,LIBELLE_CATEGORIE")] CATEGORIE cATEGORIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIE);
        }

        // GET: Administration/Categorie/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIE cATEGORIE = db.CATEGORIE.Find(id);
            if (cATEGORIE == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIE);
        }

        // POST: Administration/Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            CATEGORIE cATEGORIE = db.CATEGORIE.Find(id);
            db.CATEGORIE.Remove(cATEGORIE);
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
