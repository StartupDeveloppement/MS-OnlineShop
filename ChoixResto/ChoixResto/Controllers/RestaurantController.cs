using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ChoixResto.Models;

namespace ChoixResto.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            using (Dal dal = new Dal())
            {
                List<Resto> listeDesRestaurants = dal.ObtientTousLesRestaurants();
                return View(listeDesRestaurants);
            }
        }
        //public ActionResult ModifierRestaurant(int? id, string nom, string telephone)
        //{
            // On peut se passer du paramètre id car on utilise l'url pour la récupérer
            // string id = Request.Url.AbsolutePath.Split('/').Last();

            // Avec paramètre : int? id
            //if (id.HasValue)
            //{
            //    ViewBag.Id = id;
            //    return View();
            //}
            //else
            //    return View("Error");

            // Sans paramètre
            //string idStr = Request.QueryString["id"];
            //int id;
            //if (int.TryParse(idStr, out id))
            //{
            //    ViewBag.Id = id;
            //    return View();
            //}
            //else
            //    return View("Error");

            // 1ère méthode param : int? id
            //if (id.HasValue)
            //{
            //    using (IDal dal = new Dal())
            //    {
            //        Resto restaurant = dal.ObtientTousLesRestaurants().FirstOrDefault(r => r.Id == id.Value);
            //        if (restaurant == null)
            //            return View("Error");
            //        return View(restaurant);
            //    }
            //}
            //else
            //    return View("Error");

            // Vérifie si POST ou GET et récupère données de la query, param : int? id
            //if (id.HasValue)
            //{
            //    using (IDal dal = new Dal())
            //    {
            //        if (Request.HttpMethod == "POST")
            //        {
            //            string nouveauNom = Request.Form["Nom"];
            //            string nouveauTelephone = Request.Form["Telephone"];
            //            dal.ModifierRestaurant(id.Value, nouveauNom, nouveauTelephone);
            //        }

            //        Resto restaurant = dal.ObtientTousLesRestaurants().FirstOrDefault(r => r.Id == id.Value);
            //        if (restaurant == null)
            //            return View("Error");
            //        return View(restaurant);
            //    }
            //}
            //else
            //    return View("Error");

            // Même mais simplifié, on récupère les données si en POST, ainsi nom et telephone sont automatiquement initialisée
        //    if (id.HasValue)
        //    {
        //        using (IDal dal = new Dal())
        //        {
        //            if (Request.HttpMethod == "POST")
        //            {
        //                dal.ModifierRestaurant(id.Value, nom, telephone);
        //            }

        //            Resto restaurant = dal.ObtientTousLesRestaurants().FirstOrDefault(r => r.Id == id.Value);
        //            if (restaurant == null)
        //                return View("Error");
        //            return View(restaurant);
        //        }
        //    }
        //    else
        //        return View("Error");
        //}

        public ActionResult ModifierRestaurant(int? id)
        {
            if (id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    Resto restaurant = dal.ObtientTousLesRestaurants().FirstOrDefault(r => r.Id == id.Value);
                    if (restaurant == null)
                        return View("Error");
                    return View(restaurant);
                }
            }
            else
                return View("Error");
        }

        // Type POST
        [HttpPost]
        public ActionResult ModifierRestaurant(Resto resto)
        {
            // Param : int? id, string nom, string telephone
            //if (id.HasValue)
            //{
            //    using (IDal dal = new Dal())
            //    {
            //        dal.ModifierRestaurant(id.Value, nom, telephone);
            //        return RedirectToAction("Index");
            //    }
            //}
            //else
            //    return View("Error");
            using (IDal dal = new Dal())
            {
                dal.ModifierRestaurant(resto.Id, resto.Nom, resto.Telephone);
                return RedirectToAction("Index");
            }
        }
    }
}