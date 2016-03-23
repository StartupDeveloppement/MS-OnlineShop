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
    public class ProduitController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Produit
        public ActionResult Index()
        {
            var pRODUIT = db.PRODUIT.Include(p => p.CATEGORIE);
            return View(pRODUIT.ToList());
        }

        // GET: Administration/Produit/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT pRODUIT = db.PRODUIT.Find(id);
            if (pRODUIT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT);
        }

        // GET: Administration/Produit/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIE = new SelectList(db.CATEGORIE, "ID_CATEGORIE", "LIBELLE_CATEGORIE");
            return View();
        }

        // POST: Administration/Produit/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUIT,ID_CATEGORIE,LIBELLE_PRODUIT,DESCRIPTION_PRODUIT,DESCRIPTIF_TECHNIQUE_PRODUIT,TYPE_PRODUIT,MOTCLE_PRODUIT,DATE_MISE_EN_LIGNE_PRODUIT")] PRODUIT pRODUIT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUIT.Add(pRODUIT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIE = new SelectList(db.CATEGORIE, "ID_CATEGORIE", "LIBELLE_CATEGORIE", pRODUIT.ID_CATEGORIE);
            return View(pRODUIT);
        }

        // GET: Administration/Produit/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT pRODUIT = db.PRODUIT.Find(id);
            if (pRODUIT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIE = new SelectList(db.CATEGORIE, "ID_CATEGORIE", "LIBELLE_CATEGORIE", pRODUIT.ID_CATEGORIE);
            return View(pRODUIT);
        }

        // POST: Administration/Produit/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUIT,ID_CATEGORIE,LIBELLE_PRODUIT,DESCRIPTION_PRODUIT,DESCRIPTIF_TECHNIQUE_PRODUIT,TYPE_PRODUIT,MOTCLE_PRODUIT,DATE_MISE_EN_LIGNE_PRODUIT")] PRODUIT pRODUIT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUIT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIE = new SelectList(db.CATEGORIE, "ID_CATEGORIE", "LIBELLE_CATEGORIE", pRODUIT.ID_CATEGORIE);
            return View(pRODUIT);
        }

        // GET: Administration/Produit/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT pRODUIT = db.PRODUIT.Find(id);
            if (pRODUIT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT);
        }

        // POST: Administration/Produit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PRODUIT pRODUIT = db.PRODUIT.Find(id);
            db.PRODUIT.Remove(pRODUIT);
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
