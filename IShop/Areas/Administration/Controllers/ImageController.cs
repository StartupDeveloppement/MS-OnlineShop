using System;
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
    public class ImageController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Image
        public ActionResult Index()
        {
            var iMAGE = db.IMAGE.Include(i => i.PRODUIT);
            return View(iMAGE.ToList());
        }

        // GET: Administration/Image/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGE.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // GET: Administration/Image/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT");
            return View();
        }

        // POST: Administration/Image/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_IMAGE,ID_PRODUIT,TYPE_IMAGE,TAILLE_IMAGE,CHEMIN_IMAGE,ORDRE_IMAGE")] IMAGE iMAGE)
        {
            if (ModelState.IsValid)
            {
                db.IMAGE.Add(iMAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT", iMAGE.ID_PRODUIT);
            return View(iMAGE);
        }

        // GET: Administration/Image/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGE.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT", iMAGE.ID_PRODUIT);
            return View(iMAGE);
        }

        // POST: Administration/Image/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_IMAGE,ID_PRODUIT,TYPE_IMAGE,TAILLE_IMAGE,CHEMIN_IMAGE,ORDRE_IMAGE")] IMAGE iMAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT", iMAGE.ID_PRODUIT);
            return View(iMAGE);
        }

        // GET: Administration/Image/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGE iMAGE = db.IMAGE.Find(id);
            if (iMAGE == null)
            {
                return HttpNotFound();
            }
            return View(iMAGE);
        }

        // POST: Administration/Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            IMAGE iMAGE = db.IMAGE.Find(id);
            db.IMAGE.Remove(iMAGE);
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
