using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            CATEGORIE categorie;
            using (var db = new Database1Entities())
            {
                categorie = db.CATEGORIE.Where(c=>c.ID_CATEGORIE==1).First();
            }

               // var user = new UTILISATEUR { ID_UTILISATEUR =  } 

            return View(categorie);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}