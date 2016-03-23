using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IShop.Models;

namespace IShop.ViewModels
{
    public class UtilisateurViewModel
    {
        public UTILISATEUR Utilisateur { get; set; }
        public bool Authentifie { get; set; }
    }
}