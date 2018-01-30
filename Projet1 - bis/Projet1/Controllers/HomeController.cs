using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Projet1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //Afficher la première vue
        public ActionResult Index()
        {
            return View();
        }
        
    }
}