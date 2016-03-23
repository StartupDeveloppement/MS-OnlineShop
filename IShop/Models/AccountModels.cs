using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class AccountModels
    {
        public UTILISATEUR utilisateur;

        public AccountModels()
        {

        }

        public UTILISATEUR Login(UTILISATEUR user)
        {
            using (var db = new DataBaseIShopEntities())
            {
                utilisateur = db.UTILISATEUR.Where(u => u.EMAIL_UTILISATEUR == user.EMAIL_UTILISATEUR)
                    .Where(u => u.MDP_UTILISATEUR == user.MDP_UTILISATEUR).First();
                //utilisateur = db.UTILISATEUR.FirstOrDefault(u => u.EMAIL_UTILISATEUR == user.EMAIL_UTILISATEUR);

                return utilisateur;
            }
        }
        public void CreerUtilisateur(UTILISATEUR user)
        {
            using (var db = new DataBaseIShopEntities())
            {
                db.UTILISATEUR.Add(new UTILISATEUR { NOM_UTILISATEUR = user.NOM_UTILISATEUR, PRENOM_UTILISATEUR = user.PRENOM_UTILISATEUR,
                    EMAIL_UTILISATEUR = user.EMAIL_UTILISATEUR, MDP_UTILISATEUR = user.MDP_UTILISATEUR, TYPE_UTILISATEUR = "Client",
                    ADR_UTILISATEUR = user.ADR_UTILISATEUR});
                db.SaveChanges();
            }
        }
        public bool UtilisateurExiste(UTILISATEUR user)
        {
            using (var db = new DataBaseIShopEntities())
            {
                return db.UTILISATEUR.Any(utilisateur => string.Compare(utilisateur.EMAIL_UTILISATEUR, user.EMAIL_UTILISATEUR, StringComparison.CurrentCultureIgnoreCase) == 0);
            }
        }
    }
}
