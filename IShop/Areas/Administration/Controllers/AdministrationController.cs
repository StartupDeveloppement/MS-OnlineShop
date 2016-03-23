using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IShop.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration/Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}