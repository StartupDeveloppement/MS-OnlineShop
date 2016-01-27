using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ChoixResto.Models;
using ChoixResto.ViewModels;

namespace ChoixResto.Controllers
{
    public class AccueilController : Controller
    {
        // Vue et model
        public ActionResult Index()
        {
            // Dictionnaire
            ViewData["message"] = "Bonjour depuis le contrôleur";
            ViewData["date"] = DateTime.Now;
            ViewData["resto"] = new Resto { Nom = "Choucroute party", Telephone = "1234" };
            // Type Dynamique
            ViewBag.message = "Bonjour depuis le contrôleur";
            ViewBag.date = DateTime.Now;
            ViewBag.resto = new Resto { Nom = "Choucroute party", Telephone = "1234" };

            return View();

            // équivaut à : return View("Index");
            // on peut retourner n'importe quel View : return View("Bonjour");
            // et dans n'importe quel répertoire : return View("~/Views/Test/Essai.cshtml");
        }
        // Model
        public ActionResult Index2()
        {
            // Avec model
            ViewBag.message = "Bonjour depuis le contrôleur";
            ViewBag.date = DateTime.Now;

            Resto r = new Resto { Nom = "La bonne fourchette", Telephone = "1234" };
            return View(r);
        }
        // ViewModel
        public ActionResult Index3()
        {
            // Avec viewModel
            AccueilViewModel vm = new AccueilViewModel
            {
                Message = "Bonjour depuis le contrôleur",
                Date = DateTime.Now,
                Resto = new Resto { Nom = "La bonne fourchette", Telephone = "1234" }
            };
            return View(vm);
        }
        public ActionResult ListeResto()
        {
            AccueilViewModel vm = new AccueilViewModel
            {
                Message = "Bonjour depuis le <span style=\"color:red\">contrôleur</span>",
                Date = DateTime.Now,
                ListeDesRestos = new List<Resto>
        {
            new Resto { Nom = "Resto pinambour", Telephone = "1234" },
            new Resto { Nom = "Resto tologie", Telephone = "1234" },
            new Resto { Nom = "Resto ride", Telephone = "5678" },
            new Resto { Nom = "Resto toro", Telephone = "555" },
        }
            };
            return View(vm);
        }
        // Helper
        public ActionResult ListeDesRestos()
        {
            List<Models.Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "5678" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "555" },
            };

            ViewBag.ListeDesRestos = new SelectList(listeDesRestos, "Id", "Nom");

            return View();
        }
        // Vue partiel
        [ChildActionOnly]
        public ActionResult AfficheListeRestaurant()
        {
            List<Models.Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "5678" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "555" },
            };
            return PartialView(listeDesRestos);
        }
        // Encodage et sécurité
        public ActionResult Encodage()
        {
            AccueilViewModel vm = new AccueilViewModel
            {
                Message = "Bonjour depuis le <span style=\"color:red\">contrôleur</span>"
            };
            return View(vm);
        }
    }
}