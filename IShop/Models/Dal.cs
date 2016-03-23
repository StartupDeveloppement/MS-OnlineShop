using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace IShop.Models
{
    public class Dal : IDisposable
    {
        public DataBaseIShopEntities bdd { get; set; }

        public Dal()
        {
            bdd = new DataBaseIShopEntities();
        }
        public void Dispose()
        {
            bdd.Dispose();
        }
        //public int AjouterUtilisateur(UTILISATEUR utilisateurParam)
        //{
        //    UTILISATEUR utilisateur = new UTILISATEUR
        //    {
        //        NOM_UTILISATEUR = utilisateurParam.NOM_UTILISATEUR,
        //        PRENOM_UTILISATEUR = utilisateurParam.PRENOM_UTILISATEUR,
        //        EMAIL_UTILISATEUR = utilisateurParam.EMAIL_UTILISATEUR,
        //        MDP_UTILISATEUR = utilisateurParam.MDP_UTILISATEUR,
        //        TYPE_UTILISATEUR = "Client",
        //        ADR_UTILISATEUR = utilisateurParam.ADR_UTILISATEUR
        //    };
        //    bdd.UTILISATEUR.Add(utilisateur);
        //    bdd.SaveChanges();
        //    return utilisateur.ID_UTILISATEUR;
        //}
        //public UTILISATEUR Authentifier(string email, string motDePasse)
        //{
        //    string motDePasseEncode = motDePasse;
        //    return bdd.UTILISATEUR.FirstOrDefault(u => u.EMAIL_UTILISATEUR == email && u.MDP_UTILISATEUR == motDePasseEncode);
        //}

        //public UTILISATEUR ObtenirUtilisateur(int id)
        //{
        //    return bdd.UTILISATEUR.FirstOrDefault(u => u.ID_UTILISATEUR == id);
        //}

        //public UTILISATEUR ObtenirUtilisateur(string idStr)
        //{
        //    int id;
        //    if (int.TryParse(idStr, out id))
        //        return ObtenirUtilisateur(id);
        //    return null;
        //}
        //private string EncodeMD5(string motDePasse)
        //{
        //    string motDePasseSel = "IShop" + motDePasse + "ASP.NET MVC";
        //    return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        //}
    }
}
