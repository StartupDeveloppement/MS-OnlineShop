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
    public class CommandeController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Commande
        public ActionResult Index()
        {
            var cOMMANDE = db.COMMANDE.Include(c => c.UTILISATEUR);
            return View(cOMMANDE.ToList());
        }

        // GET: Administration/Commande/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMANDE cOMMANDE = db.COMMANDE.Find(id);
            if (cOMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMANDE);
        }

        // GET: Administration/Commande/Create
        public ActionResult Create()
        {
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR");
            return View();
        }

        // POST: Administration/Commande/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_COMMANDE,ID_UTILISATEUR,TYPE_COMMANDE,DATE_COMMANDE,DATE_ESTIME_COMMANDE,ADR_LIVRAISON_COMMANDE,ETAT_COMMANDE,LIEU_ACTUEL_COMMANDE")] COMMANDE cOMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.COMMANDE.Add(cOMMANDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", cOMMANDE.ID_UTILISATEUR);
            return View(cOMMANDE);
        }

        // GET: Administration/Commande/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMANDE cOMMANDE = db.COMMANDE.Find(id);
            if (cOMMANDE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", cOMMANDE.ID_UTILISATEUR);
            return View(cOMMANDE);
        }

        // POST: Administration/Commande/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_COMMANDE,ID_UTILISATEUR,TYPE_COMMANDE,DATE_COMMANDE,DATE_ESTIME_COMMANDE,ADR_LIVRAISON_COMMANDE,ETAT_COMMANDE,LIEU_ACTUEL_COMMANDE")] COMMANDE cOMMANDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMMANDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_UTILISATEUR = new SelectList(db.UTILISATEUR, "ID_UTILISATEUR", "NOM_UTILISATEUR", cOMMANDE.ID_UTILISATEUR);
            return View(cOMMANDE);
        }

        // GET: Administration/Commande/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMMANDE cOMMANDE = db.COMMANDE.Find(id);
            if (cOMMANDE == null)
            {
                return HttpNotFound();
            }
            return View(cOMMANDE);
        }

        // POST: Administration/Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            COMMANDE cOMMANDE = db.COMMANDE.Find(id);
            db.COMMANDE.Remove(cOMMANDE);
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
