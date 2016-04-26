using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IShop.Models;

namespace IShop.Controllers
{
    public class PanierController : Controller
    {
        private PanierModel panierModel;
        public PanierController() : this(new PanierModel())
        {

        }
        private PanierController(PanierModel panierModelIoc)
        {
            panierModel = panierModelIoc;
        }
        // GET: Panier
        public ActionResult Index()
        {
            UTILISATEUR utilisateur = (UTILISATEUR)Session["CurrentUSer"];
            if (utilisateur != null)
            {
                //COMMANDE panier = panierModel.listeProduitPanier(utilisateur.ID_UTILISATEUR);
                List<PRODUIT> panier = panierModel.listeProduitPanier(utilisateur.ID_UTILISATEUR);
                return View(panier);
            }
            return View();
        }

        //public ActionResult AjoutPanier(short? id)
        //{

        //    PRODUIT p1 = panierModel.getProduit(id);

        //    UTILISATEUR utilisateur = (UTILISATEUR)Session["CurrentUSer"];
        //    if (utilisateur != null)
        //    {
        //        panierModel.AjoutProduitPanier(p1.ID_PRODUIT, utilisateur.ID_UTILISATEUR);
        //        return RedirectToAction("Index");
        //    }
        //    return View("Index");
        //}
        public ActionResult AjoutPanier()
        {
            short id = (short)Session["CurrentProdId"];
            PRODUIT p1 = panierModel.getProduit(id);

            UTILISATEUR utilisateur = (UTILISATEUR)Session["CurrentUSer"];
            if (utilisateur != null)
            {
                panierModel.AjoutProduitPanier(p1.ID_PRODUIT, utilisateur.ID_UTILISATEUR);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public ActionResult SupprimerPanier(short? id)
        {
            //short id = (short)Session["CurrentProdId"];
            PRODUIT p1 = panierModel.getProduit(id);

            UTILISATEUR utilisateur = (UTILISATEUR)Session["CurrentUSer"];
            if (utilisateur != null)
            {
                panierModel.SupprimerProduitPanier(p1.ID_PRODUIT, utilisateur.ID_UTILISATEUR);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}