using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Models
{
    class PanierModel
    {
        private Dal dal;

        public PanierModel()
        {
            dal = new Dal();
        }
        public COMMANDE creerPanier(short id)
        {
            COMMANDE panier = new COMMANDE
            {
                ID_UTILISATEUR = id,
                TYPE_COMMANDE = "Panier"
            };
            dal.bdd.COMMANDE.Add(panier);
            dal.bdd.SaveChanges();
            return panier;
        }
        //public COMMANDE listeProduitPanier(short? id)
        //{
        //    COMMANDE panier = dal.bdd.COMMANDE.FirstOrDefault(u => u.ID_UTILISATEUR == id && u.TYPE_COMMANDE == "Panier");
        //    if (panier != null)
        //    {
        //        return panier;
        //    }
        //    else
        //    {
        //        panier = creerPanier(id);
        //        return panier;
        //    }
        //}
        public List<PRODUIT> listeProduitPanier(short id)
        {
            List<PRODUIT> produitPanier = new List<PRODUIT>();
            List<PRODUIT_COMMANDE> produitCommande = new List<PRODUIT_COMMANDE>();

            COMMANDE panier = dal.bdd.COMMANDE.FirstOrDefault(u => u.ID_UTILISATEUR == id && u.TYPE_COMMANDE == "Panier");
            if(panier == null)
            {
                panier = creerPanier(id);
            }
            List<PRODUIT_COMMANDE> list_Pc = dal.bdd.PRODUIT_COMMANDE.ToList();
            foreach (PRODUIT_COMMANDE pc1 in list_Pc)
            {
                if(pc1.ID_COMMANDE == panier.ID_COMMANDE)
                {
                    produitCommande.Add(pc1);
                }
            }
            //produitCommande = dal.bdd.PRODUIT_COMMANDE.Where(c => c.ID_COMMANDE == panier.ID_COMMANDE).ToList();
            foreach(PRODUIT_COMMANDE pC in produitCommande)
            {
                PRODUIT pPanier = dal.bdd.PRODUIT.FirstOrDefault(p => p.ID_PRODUIT == pC.ID_PRODUIT);
                produitPanier.Add(pPanier);
            }
            return produitPanier;
        }

        public void AjoutProduitPanier(short idProduit, short idUtilisateur)
        {
            COMMANDE panier = dal.bdd.COMMANDE.FirstOrDefault(u => u.ID_UTILISATEUR == idUtilisateur && u.TYPE_COMMANDE == "Panier");
            if (panier == null)
            {
                panier = creerPanier(idUtilisateur);
            }
            PRODUIT_SOCIETE ps = dal.bdd.PRODUIT_SOCIETE.FirstOrDefault(ps1 => ps1.ID_PRODUIT == idProduit);
            PRODUIT_COMMANDE produitCommande = new PRODUIT_COMMANDE
            {
                ID_PRODUIT = idProduit,
                ID_COMMANDE = panier.ID_COMMANDE,
                ID_SOCIETE = 1,
                ID_PRODUIT_SOCIETE = ps.ID_PRODUIT_SOCIETE
            };
            dal.bdd.PRODUIT_COMMANDE.Add(produitCommande);
            dal.bdd.SaveChanges();
        }
        public PRODUIT getProduit(short? id)
        {
            return dal.bdd.PRODUIT.Find(id);
        }
        public void SupprimerProduitPanier(short idProduit, short idUtilisateur)
        {
            COMMANDE panier = dal.bdd.COMMANDE.FirstOrDefault(u => u.ID_UTILISATEUR == idUtilisateur && u.TYPE_COMMANDE == "Panier");
            PRODUIT_COMMANDE produitCommande = dal.bdd.PRODUIT_COMMANDE.FirstOrDefault(pc => pc.ID_PRODUIT == idProduit && pc.ID_COMMANDE == panier.ID_COMMANDE);
            dal.bdd.PRODUIT_COMMANDE.Remove(produitCommande);
            dal.bdd.SaveChanges();
        }
    }
}
