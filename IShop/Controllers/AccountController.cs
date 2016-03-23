using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

namespace IShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Connexion(UTILISATEUR utilisateur)
        {
            UTILISATEUR user;
            string typeUser;

            Models.AccountModels accountModels = new Models.AccountModels();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("EMAIL_UTILISATEUR", "Cet email n'existe pas");
                return View("Login");
            }
            else {
                user = accountModels.Login(utilisateur);
                typeUser = user.TYPE_UTILISATEUR;
                switch (typeUser.Trim())
                {
                    case "Admin":
                        return Content("Connecté en mode admin" + user.EMAIL_UTILISATEUR + ", " + user.MDP_UTILISATEUR + ", " + user.TYPE_UTILISATEUR);
                        break;
                    case "Vendeur":
                        return Content("Connecté en mode vendeur" + user.EMAIL_UTILISATEUR + ", " + user.MDP_UTILISATEUR + ", " + user.TYPE_UTILISATEUR);
                        break;
                    case "Client":
                        return Content("Connecté en mode client" + user.EMAIL_UTILISATEUR + ", " + user.MDP_UTILISATEUR + ", " + user.TYPE_UTILISATEUR);
                        break;
                    default:
                        return Content(":/" + user.EMAIL_UTILISATEUR + ", " + user.MDP_UTILISATEUR + ", " + user.TYPE_UTILISATEUR);
                        break;
                }
            } 
        }
       
        public ActionResult creerUtilisateur(UTILISATEUR utilisateur)
        {
            Models.AccountModels accountModels = new Models.AccountModels();
            if (accountModels.UtilisateurExiste(utilisateur))
            {
                ModelState.AddModelError("EMAIL_UTILISATEUR", "Cet email est déjà utilisé");
                return View(utilisateur);
            }
            if (!ModelState.IsValid)
                return View(utilisateur);
            accountModels.CreerUtilisateur(utilisateur);
            return Content("Connecté en mode client");
        }
    }
}