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
    public class HomeController : Controller
    {
        // GET: Home
        
        private ProduitModel ProduitModel;
        public HomeController() : this(new ProduitModel())
        {

        }
        private HomeController(ProduitModel ProduitModelIoc)
        {
            ProduitModel = ProduitModelIoc;
        }
        public ActionResult Index()
        {
            List<PRODUIT> listeDesProduits = ProduitModel.ObtientTousLesProduits();
            return View(listeDesProduits);
        }
        public ActionResult FicheProduit(short? id)
        {
            PRODUIT produit = ProduitModel.getProduit(id);
            return View(produit);
        }
        public ActionResult AjoutPanier(short? id)
       {
            //return RedirectToAction("AjoutPanier", "Panier", id);
            Session["CurrentProdId"] = id;
            return RedirectToAction("AjoutPanier", "Panier");
        }
    }
}