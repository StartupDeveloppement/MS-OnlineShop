using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IShop.Models;
using IShop.ViewModels;
using System.Web.Security;

namespace IShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //private Dal dal;

        //public LoginController() : this(new Dal())
        //{

        //}

        //private LoginController(Dal dalIoc)
        //{
        //    dal = dalIoc;
        //}
        private UtilisateurModel utilisateurModel;
        public LoginController() : this(new UtilisateurModel())
        {

        }

        private LoginController(UtilisateurModel utilisateurModelIoc)
        {
            utilisateurModel = utilisateurModelIoc;
        }
        public ActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Utilisateur = utilisateurModel.ObtenirUtilisateur(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UtilisateurViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UTILISATEUR utilisateur = utilisateurModel.Authentifier(viewModel.Utilisateur.EMAIL_UTILISATEUR, viewModel.Utilisateur.MDP_UTILISATEUR);
                if (utilisateur != null)
                {
                    FormsAuthentication.SetAuthCookie(utilisateur.ID_UTILISATEUR.ToString(), false);
                    // Retour la où l'utilisateur a essayer d'accèder
                    //if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    //    return Redirect(returnUrl);
                    switch (utilisateur.TYPE_UTILISATEUR.Trim())
                    {
                        case "Admin":
                            return RedirectToAction("Index", "Administration", new { area = "Administration" });
                            break;
                        case "Vendeur":
                            return RedirectToAction("Index", "Home", new { area = "Vendeur" });
                            break;
                        case "Client":
                            return Content(HttpContext.User.Identity.Name.ToString());//RedirectToAction("Index", "Home", new { area = "Client" });
                            break;
                        default:
                            return Redirect("/");
                            break;
                    }
                    
                }
                ModelState.AddModelError("Utilisateur.EMAIL_UTILISATEUR", "Email et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerCompte(UTILISATEUR utilisateur)
        {
            if (ModelState.IsValid)
            {
                int id = utilisateurModel.AjouterUtilisateur(utilisateur);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View(utilisateur);
        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}