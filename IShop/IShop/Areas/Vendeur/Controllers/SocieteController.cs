using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IShop.Areas.Vendeur.Models;
using System.Web.Security;

namespace IShop.Areas.Vendeur.Controllers
{
    public class SocieteController : Controller
    {
        private SocieteModel societeModel;
        public SocieteController() : this(new SocieteModel())
        {

        }
        private SocieteController(SocieteModel societeModelIoc)
        {
            societeModel = societeModelIoc;
        }

        // GET: Vendeur/Societe
        public ActionResult Index()
        {
            string sIdUtilisateur = HttpContext.User.Identity.Name;
            short shortIdUtilisateur;
            SOCIETE societe = new SOCIETE();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (short.TryParse(sIdUtilisateur, out shortIdUtilisateur))
                { 
                    societe = societeModel.TrouveSociete(shortIdUtilisateur);
                }
                else
                {
                    return Content("Error");
                }
            }
            return View(societe);
        }
        [HttpPost]
        public ActionResult Index(SOCIETE societe)
        {
            return View(societe);
        }
    }
}