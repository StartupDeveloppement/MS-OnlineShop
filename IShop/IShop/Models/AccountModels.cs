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
        bool result;

        public AccountModels()
        {

        }

        public bool Login(string email, string mdp)
        {
            using (var db = new DataBaseIShopEntities())
            {
                utilisateur = db.UTILISATEUR.Where(u => u.EMAIL_UTILISATEUR == email)
                    .Where(u => u.MDP_UTILISATEUR == mdp).First();
                if (utilisateur != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
