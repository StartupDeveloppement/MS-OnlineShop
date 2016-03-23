using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IShop.Areas.Vendeur.Controllers
{
    public class HomeController : Controller
    {
        // GET: Vendeur/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}