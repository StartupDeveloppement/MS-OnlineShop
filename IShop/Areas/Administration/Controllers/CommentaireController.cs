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
    public class CommentaireController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Commentaire
        public ActionResult Index()
        {
            var cOMMENTAIRE = db.COMMENTAIRE.Include(c => c.PRODUIT_SOCIETE).Include(c => c.SOCIETE).Include(c => c.UTILISATEUR);
            return View(cOMMENTAIRE.ToList());
        }

        // GET: Administration/Commentaire/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIRE.Find(id);
            if (cOMMENTAIRE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENTAIRE);
        }

        // GET: Administration/Commentaire/Create
        public ActionResult Create()
        {
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT");
            ViewBag.ID_SOCIETE_REL_6 = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE");
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR");
            return View();
        }

        // POST: Administration/Commentaire/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COMMENTAIRE,ID_UTILISATEUR,ID_SOCIETE,ID_PRODUIT,ID_PRODUIT_SOCIETE,ID_SOCIETE_REL_6,LIBELLE_COMMENTAIRE,CONTENU_COMMENTAIRE,DATE_COMMENTAIRE,DATE_MODIFICATION_COMMENTAIRE,NOTE_COMMENTAIRE")] COMMENTAIRE cOMMENTAIRE)
        {
            if (ModelState.IsValid)
            {
                db.COMMENTAIRE.Add(cOMMENTAIRE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT", cOMMENTAIRE.ID_SOCIETE);
            ViewBag.ID_SOCIETE_REL_6 = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", cOMMENTAIRE.ID_SOCIETE_REL_6);
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", cOMMENTAIRE.ID_UTILISATEUR);
            return View(cOMMENTAIRE);
        }

        // GET: Administration/Commentaire/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIRE.Find(id);
            if (cOMMENTAIRE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT", cOMMENTAIRE.ID_SOCIETE);
            ViewBag.ID_SOCIETE_REL_6 = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", cOMMENTAIRE.ID_SOCIETE_REL_6);
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", cOMMENTAIRE.ID_UTILISATEUR);
            return View(cOMMENTAIRE);
        }

        // POST: Administration/Commentaire/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COMMENTAIRE,ID_UTILISATEUR,ID_SOCIETE,ID_PRODUIT,ID_PRODUIT_SOCIETE,ID_SOCIETE_REL_6,LIBELLE_COMMENTAIRE,CONTENU_COMMENTAIRE,DATE_COMMENTAIRE,DATE_MODIFICATION_COMMENTAIRE,NOTE_COMMENTAIRE")] COMMENTAIRE cOMMENTAIRE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMENTAIRE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SOCIETE = new SelectList(db.PRODUIT_SOCIETE, "ID_SOCIETE", "ETAT_PRODUIT", cOMMENTAIRE.ID_SOCIETE);
            ViewBag.ID_SOCIETE_REL_6 = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", cOMMENTAIRE.ID_SOCIETE_REL_6);
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", cOMMENTAIRE.ID_UTILISATEUR);
            return View(cOMMENTAIRE);
        }

        // GET: Administration/Commentaire/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIRE.Find(id);
            if (cOMMENTAIRE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMENTAIRE);
        }

        // POST: Administration/Commentaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COMMENTAIRE cOMMENTAIRE = db.COMMENTAIRE.Find(id);
            db.COMMENTAIRE.Remove(cOMMENTAIRE);
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
