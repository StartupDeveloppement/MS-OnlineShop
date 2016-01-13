using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            bool result;
            Models.AccountModels accountModels = new Models.AccountModels();
            result = accountModels.Login(utilisateur.EMAIL_UTILISATEUR, utilisateur.MDP_UTILISATEUR);
            if (result)
            {
                return View("Register");
            }
            else
            {
                return View("Login");
            }
        }
    }
}