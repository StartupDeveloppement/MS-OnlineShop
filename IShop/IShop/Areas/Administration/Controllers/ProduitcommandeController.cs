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
    public class ProduitcommandeController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Produitcommande
        public ActionResult Index()
        {
            var pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Include(p => p.COMMANDE).Include(p => p.PRODUIT_SOCIETE);
            return View(pRODUIT_COMMANDE.ToList());
        }

        // GET: Administration/Produitcommande/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            if (pRODUIT_COMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT_COMMANDE);
        }

        // GET: Administration/Produitcommande/Create
        public ActionResult Create()
        {
            ViewBag.ID_COMMANDE = new SelectList(db.COMMANDE, "ID_COMMANDE", "TYPE_COMMANDE");
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT");
            return View();
        }

        // POST: Administration/Produitcommande/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COMMANDE,ID_SOCIETE,ID_PRODUIT,ID_PRODUIT_SOCIETE,ETAT_PRODUIT_COMMANDE")] PRODUIT_COMMANDE pRODUIT_COMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.PRODUIT_COMMANDE.Add(pRODUIT_COMMANDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMMANDE = new SelectList(db.COMMANDE, "ID_COMMANDE", "TYPE_COMMANDE", pRODUIT_COMMANDE.ID_COMMANDE);
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT", pRODUIT_COMMANDE.ID_SOCIETE);
            return View(pRODUIT_COMMANDE);
        }

        // GET: Administration/Produitcommande/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            if (pRODUIT_COMMANDE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMMANDE = new SelectList(db.COMMANDE, "ID_COMMANDE", "TYPE_COMMANDE", pRODUIT_COMMANDE.ID_COMMANDE);
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT", pRODUIT_COMMANDE.ID_SOCIETE);
            return View(pRODUIT_COMMANDE);
        }

        // POST: Administration/Produitcommande/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COMMANDE,ID_SOCIETE,ID_PRODUIT,ID_PRODUIT_SOCIETE,ETAT_PRODUIT_COMMANDE")] PRODUIT_COMMANDE pRODUIT_COMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUIT_COMMANDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMMANDE = new SelectList(db.COMMANDE, "ID_COMMANDE", "TYPE_COMMANDE", pRODUIT_COMMANDE.ID_COMMANDE);
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT", pRODUIT_COMMANDE.ID_SOCIETE);
            return View(pRODUIT_COMMANDE);
        }

        // GET: Administration/Produitcommande/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            if (pRODUIT_COMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUIT_COMMANDE);
        }

        // POST: Administration/Produitcommande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PRODUIT_COMMANDE pRODUIT_COMMANDE = db.PRODUIT_COMMANDE.Find(id);
            db.PRODUIT_COMMANDE.Remove(pRODUIT_COMMANDE);
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
