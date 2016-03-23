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
    public class PaysController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Pays
        public ActionResult Index()
        {
            return View(db.PAYS.ToList());
        }

        // GET: Administration/Pays/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYS pAYS = db.PAYS.Find(id);
            if (pAYS == null)
            {
                return HttpNotFound();
            }
            return View(pAYS);
        }

        // GET: Administration/Pays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Pays/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAYS,LIBELLE_PAYS,CODE_PAYS")] PAYS pAYS)
        {
            if (ModelState.IsValid)
            {
                db.PAYS.Add(pAYS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAYS);
        }

        // GET: Administration/Pays/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYS pAYS = db.PAYS.Find(id);
            if (pAYS == null)
            {
                return HttpNotFound();
            }
            return View(pAYS);
        }

        // POST: Administration/Pays/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAYS,LIBELLE_PAYS,CODE_PAYS")] PAYS pAYS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAYS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAYS);
        }

        // GET: Administration/Pays/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYS pAYS = db.PAYS.Find(id);
            if (pAYS == null)
            {
                return HttpNotFound();
            }
            return View(pAYS);
        }

        // POST: Administration/Pays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PAYS pAYS = db.PAYS.Find(id);
            db.PAYS.Remove(pAYS);
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
