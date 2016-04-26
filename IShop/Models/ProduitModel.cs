using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Models
{
    class ProduitModel
    {
        private Dal dal;

        public ProduitModel()
        {
            dal = new Dal();
        }
        public List<PRODUIT> ObtientTousLesProduits()
        {
            return dal.bdd.PRODUIT.ToList();
        }
        public PRODUIT getProduit(short? id)
        {
            return dal.bdd.PRODUIT.Find(id);
        }
    }
}
