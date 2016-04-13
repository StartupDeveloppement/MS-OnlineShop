using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace IShop.Models
{
    public class UtilisateurModel
    {
        private Dal dal;

        public UtilisateurModel()
        {
            dal = new Dal();
        }
        public int AjouterUtilisateur(UTILISATEUR utilisateurParam)
        {
            UTILISATEUR utilisateur = new UTILISATEUR
            {
                NOM_UTILISATEUR = utilisateurParam.NOM_UTILISATEUR,
                PRENOM_UTILISATEUR = utilisateurParam.PRENOM_UTILISATEUR,
                EMAIL_UTILISATEUR = utilisateurParam.EMAIL_UTILISATEUR,
                MDP_UTILISATEUR = utilisateurParam.MDP_UTILISATEUR,
                TYPE_UTILISATEUR = "Client",
                ADR_UTILISATEUR = utilisateurParam.ADR_UTILISATEUR
            };
            dal.bdd.UTILISATEUR.Add(utilisateur);
            dal.bdd.SaveChanges();
            return utilisateur.ID_UTILISATEUR;
        }
        public UTILISATEUR Authentifier(string email, string motDePasse)
        {
            return dal.bdd.UTILISATEUR.FirstOrDefault(u => u.EMAIL_UTILISATEUR == email && u.MDP_UTILISATEUR == motDePasse);
        }

        public UTILISATEUR ObtenirUtilisateur(int id)
        {
            return dal.bdd.UTILISATEUR.FirstOrDefault(u => u.ID_UTILISATEUR == id);
        }

        public UTILISATEUR ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
                return ObtenirUtilisateur(id);
            return null;
        }
    }
}
