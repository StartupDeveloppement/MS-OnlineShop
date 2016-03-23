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
    public class PaiementController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Paiement
        public ActionResult Index()
        {
            var pAIEMENT = db.PAIEMENT.Include(p => p.UTILISATEUR);
            return View(pAIEMENT.ToList());
        }

        // GET: Administration/Paiement/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIEMENT pAIEMENT = db.PAIEMENT.Find(id);
            if (pAIEMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAIEMENT);
        }

        // GET: Administration/Paiement/Create
        public ActionResult Create()
        {
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR");
            return View();
        }

        // POST: Administration/Paiement/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAIEMENT,ID_UTILISATEUR,TYPE_CARTE_PAIEMENT,NUMERO_CARTE_PAIEMENT,CODE_CARTE_PAIEMENT,NOM_TITULAIRE_CARTE_PAIEMENT,PRENOM_TITULAIRE_CARTE_PAIEMENT,DATE_VALIDITE_CARTE_PAIEMENT,ADR_FACTURATION")] PAIEMENT pAIEMENT)
        {
            if (ModelState.IsValid)
            {
                db.PAIEMENT.Add(pAIEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", pAIEMENT.ID_UTILISATEUR);
            return View(pAIEMENT);
        }

        // GET: Administration/Paiement/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIEMENT pAIEMENT = db.PAIEMENT.Find(id);
            if (pAIEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", pAIEMENT.ID_UTILISATEUR);
            return View(pAIEMENT);
        }

        // POST: Administration/Paiement/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAIEMENT,ID_UTILISATEUR,TYPE_CARTE_PAIEMENT,NUMERO_CARTE_PAIEMENT,CODE_CARTE_PAIEMENT,NOM_TITULAIRE_CARTE_PAIEMENT,PRENOM_TITULAIRE_CARTE_PAIEMENT,DATE_VALIDITE_CARTE_PAIEMENT,ADR_FACTURATION")] PAIEMENT pAIEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAIEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", pAIEMENT.ID_UTILISATEUR);
            return View(pAIEMENT);
        }

        // GET: Administration/Paiement/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIEMENT pAIEMENT = db.PAIEMENT.Find(id);
            if (pAIEMENT == null)
            {
                return HttpNotFound();
            }
            return View(pAIEMENT);
        }

        // POST: Administration/Paiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PAIEMENT pAIEMENT = db.PAIEMENT.Find(id);
            db.PAIEMENT.Remove(pAIEMENT);
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
