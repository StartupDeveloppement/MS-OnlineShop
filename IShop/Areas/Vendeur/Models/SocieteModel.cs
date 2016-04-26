using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IShop.Models;

namespace IShop.Areas.Vendeur.Models
{
    public class SocieteModel
    {
        private Dal dal;

        public SocieteModel()
        {
            dal = new Dal();
        }
        public SOCIETE TrouveSociete(short idUtilisateur)
        {
            UTILISATEUR utilisateur = new UTILISATEUR();
            SOCIETE societe = new SOCIETE();

            utilisateur = dal.bdd.UTILISATEUR.FirstOrDefault(u => u.ID_UTILISATEUR == idUtilisateur);
            societe = dal.bdd.SOCIETE.FirstOrDefault(s => s.ID_SOCIETE == utilisateur.ID_SOCIETE);

            return societe;
        }
    }
}
