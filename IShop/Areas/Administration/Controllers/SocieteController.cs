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
    public class SocieteController : Controller
    {
        private DataBaseIShopEntities db = new DataBaseIShopEntities();

        // GET: Administration/Societe
        public ActionResult Index()
        {
            var sOCIETE = db.SOCIETE.Include(s => s.VILLE);
            return View(sOCIETE.ToList());
        }

        // GET: Administration/Societe/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIETE sOCIETE = db.SOCIETE.Find(id);
            if (sOCIETE == null)
            {
                return HttpNotFound();
            }
            return View(sOCIETE);
        }

        // GET: Administration/Societe/Create
        public ActionResult Create()
        {
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE");
            return View();
        }

        // POST: Administration/Societe/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SOCIETE,ID_VILLE,LIBELLE_SOCIETE,LOGO_SOCIETE,NUMSIRET_SOCIETE,NUMINTRA_SOCIETE,TELEPHONE_SOCIETE,FAX_SOCIETE,EMAIL_SOCIETE")] SOCIETE sOCIETE)
        {
            if (ModelState.IsValid)
            {
                db.SOCIETE.Add(sOCIETE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE", sOCIETE.ID_VILLE);
            return View(sOCIETE);
        }

        // GET: Administration/Societe/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIETE sOCIETE = db.SOCIETE.Find(id);
            if (sOCIETE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE", sOCIETE.ID_VILLE);
            return View(sOCIETE);
        }

        // POST: Administration/Societe/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SOCIETE,ID_VILLE,LIBELLE_SOCIETE,LOGO_SOCIETE,NUMSIRET_SOCIETE,NUMINTRA_SOCIETE,TELEPHONE_SOCIETE,FAX_SOCIETE,EMAIL_SOCIETE")] SOCIETE sOCIETE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOCIETE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_VILLE = new SelectList(db.VILLE, "ID_VILLE", "NOM_VILLE", sOCIETE.ID_VILLE);
            return View(sOCIETE);
        }

        // GET: Administration/Societe/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIETE sOCIETE = db.SOCIETE.Find(id);
            if (sOCIETE == null)
            {
                return HttpNotFound();
            }
            return View(sOCIETE);
        }

        // POST: Administration/Societe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            SOCIETE sOCIETE = db.SOCIETE.Find(id);
            db.SOCIETE.Remove(sOCIETE);
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
