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
    public class UtilisateurController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Utilisateur
        public ActionResult Index()
        {
            var uTILISATEUR = db.UTILISATEUR.Include(u => u.SOCIETE).Include(u => u.VILLE);
            return View(uTILISATEUR.ToList());
        }

        // GET: Administration/Utilisateur/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // GET: Administration/Utilisateur/Create
        public ActionResult Create()
        {
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE");
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE");
            return View();
        }

        // POST: Administration/Utilisateur/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_UTILISATEUR,ID_SOCIETE,ID_VILLE,NOM_UTILISATEUR,PRENOM_UTILISATEUR,EMAIL_UTILISATEUR,MDP_UTILISATEUR,DATE_NAISSANCE_UTILISATEUR,ADR_UTILISATEUR,TYPE_UTILISATEUR,DROIT_UTILISATEUR")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                db.UTILISATEUR.Add(uTILISATEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", uTILISATEUR.ID_SOCIETE);
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE", uTILISATEUR.ID_VILLE);
            return View(uTILISATEUR);
        }

        // GET: Administration/Utilisateur/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", uTILISATEUR.ID_SOCIETE);
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE", uTILISATEUR.ID_VILLE);
            return View(uTILISATEUR);
        }

        // POST: Administration/Utilisateur/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_UTILISATEUR,ID_SOCIETE,ID_VILLE,NOM_UTILISATEUR,PRENOM_UTILISATEUR,EMAIL_UTILISATEUR,MDP_UTILISATEUR,DATE_NAISSANCE_UTILISATEUR,ADR_UTILISATEUR,TYPE_UTILISATEUR,DROIT_UTILISATEUR")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uTILISATEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SOCIETE = new SelectList(db.SOCIETE, "ID_SOCIETE", "LIBELLE_SOCIETE", uTILISATEUR.ID_SOCIETE);
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE", uTILISATEUR.ID_VILLE);
            return View(uTILISATEUR);
        }

        // GET: Administration/Utilisateur/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // POST: Administration/Utilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            db.UTILISATEUR.Remove(uTILISATEUR);
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
