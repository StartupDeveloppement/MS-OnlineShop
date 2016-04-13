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
    public class ProduitsocieteController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Produitsociete
        public ActionResult Index()
        {
            var pRODUIT_SOCIETE = db.PRODUIT_SOCIETE.Include(p => p.PRODUIT).Include(p => p.SOCIETE);
            return View(pRODUIT_SOCIETE.ToList());
        }

        // GET: Administration/Produitsociete/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_SOCIETE pRODUIT_SOCIETE = db.PRODUIT_SOCIETE.Find(id);
            if (pRODUIT_SOCIETE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT_SOCIETE);
        }

        // GET: Administration/Produitsociete/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT");
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE");
            return View();
        }

        // POST: Administration/Produitsociete/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SOCIETE,ID_PRODUIT,ID_PRODUIT_SOCIETE,ETAT_PRODUIT,PRIX_PRODUIT_SOCIETE,STOCK_PRODUIT_SOCIETE,DELAI_LIVRAISON_PRODUIT_SOCIETE")] PRODUIT_SOCIETE pRODUIT_SOCIETE)
        {
            if (ModelState.IsValid)
            {
                db.PRODUIT_SOCIETE.Add(pRODUIT_SOCIETE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT", pRODUIT_SOCIETE.ID_PRODUIT);
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", pRODUIT_SOCIETE.ID_SOCIETE);
            return View(pRODUIT_SOCIETE);
        }

        // GET: Administration/Produitsociete/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_SOCIETE pRODUIT_SOCIETE = db.PRODUIT_SOCIETE.Find(id);
            if (pRODUIT_SOCIETE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT", pRODUIT_SOCIETE.ID_PRODUIT);
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", pRODUIT_SOCIETE.ID_SOCIETE);
            return View(pRODUIT_SOCIETE);
        }

        // POST: Administration/Produitsociete/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SOCIETE,ID_PRODUIT,ID_PRODUIT_SOCIETE,ETAT_PRODUIT,PRIX_PRODUIT_SOCIETE,STOCK_PRODUIT_SOCIETE,DELAI_LIVRAISON_PRODUIT_SOCIETE")] PRODUIT_SOCIETE pRODUIT_SOCIETE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUIT_SOCIETE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRODUIT = new SelectList(db.PRODUIT, "ID_PRODUIT", "LIBELLE_PRODUIT", pRODUIT_SOCIETE.ID_PRODUIT);
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", pRODUIT_SOCIETE.ID_SOCIETE);
            return View(pRODUIT_SOCIETE);
        }

        // GET: Administration/Produitsociete/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_SOCIETE pRODUIT_SOCIETE = db.PRODUIT_SOCIETE.Find(id);
            if (pRODUIT_SOCIETE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT_SOCIETE);
        }

        // POST: Administration/Produitsociete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PRODUIT_SOCIETE pRODUIT_SOCIETE = db.PRODUIT_SOCIETE.Find(id);
            db.PRODUIT_SOCIETE.Remove(pRODUIT_SOCIETE);
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
