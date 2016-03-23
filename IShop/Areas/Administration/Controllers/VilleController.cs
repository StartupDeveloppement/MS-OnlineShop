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
    public class VilleController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Ville
        public ActionResult Index()
        {
            var vILLE = db.VILLE.Include(v => v.PAYS);
            return View(vILLE.ToList());
        }

        // GET: Administration/Ville/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VILLE vILLE = db.VILLE.Find(id);
            if (vILLE == null)
            {
                return HttpNotFound();
            }
            return View(vILLE);
        }

        // GET: Administration/Ville/Create
        public ActionResult Create()
        {
            ViewBag.ID_PAYS = new SelectList(db.PAYS, "ID_PAYS", "LIBELLE_PAYS");
            return View();
        }

        // POST: Administration/Ville/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_VILLE,ID_PAYS,NOM_VILLE,CP_VILLE")] VILLE vILLE)
        {
            if (ModelState.IsValid)
            {
                db.VILLE.Add(vILLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAYS = new SelectList(db.PAYS, "ID_PAYS", "LIBELLE_PAYS", vILLE.ID_PAYS);
            return View(vILLE);
        }

        // GET: Administration/Ville/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VILLE vILLE = db.VILLE.Find(id);
            if (vILLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAYS = new SelectList(db.PAYS, "ID_PAYS", "LIBELLE_PAYS", vILLE.ID_PAYS);
            return View(vILLE);
        }

        // POST: Administration/Ville/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_VILLE,ID_PAYS,NOM_VILLE,CP_VILLE")] VILLE vILLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vILLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAYS = new SelectList(db.PAYS, "ID_PAYS", "LIBELLE_PAYS", vILLE.ID_PAYS);
            return View(vILLE);
        }

        // GET: Administration/Ville/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VILLE vILLE = db.VILLE.Find(id);
            if (vILLE == null)
            {
                return HttpNotFound();
            }
            return View(vILLE);
        }

        // POST: Administration/Ville/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            VILLE vILLE = db.VILLE.Find(id);
            db.VILLE.Remove(vILLE);
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
