using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projet1.Models;
using System.Data.SqlClient;

namespace Projet1.Controllers
{
    public class SondageController : Controller
    {
        // Afficher la vue de création d'un sondage
        public ActionResult CreerSondage()
        {
            return View("CreerSondage");
        }
        
        
        //Enregistrement d'un sondage dans la BDD
        public ActionResult SondageCree(string question, List<string> Choix, string check)
        {
            bool choixMultiple;
            if (check == "checked")
            { choixMultiple = true; }
            else choixMultiple = false;


            Choix.RemoveAll(string.IsNullOrEmpty);
            Sondage NouveauSondage = new Sondage(question, Choix, choixMultiple);
                                
            SQL.SauvegarderEnBDD(NouveauSondage); //Appel de la méthode permettant de sauvegarder dans la BDD

           
            /*
            HttpCookie MyCookie = new HttpCookie("LastVisit");
            MyCookie.Value = "la Valeur du cookie";

            Response.Cookies.Add(MyCookie);*/


            return View("SondageCree");


          
        }

        public ActionResult Sondage()
        {
            Sondage SondageBDD = new Sondage(SQL.RecupererDansBDD().Question, SQL.RecupererDansBDD().Choix, SQL.RecupererDansBDD().ChoixMultiple);
            
            return View(SondageBDD);
        }



        public ActionResult Voter(List<string> Choix)
        {
            List<bool> CheckedOuPas = new List<bool>();
            bool boolCheckedOuPas = Convert.ToBoolean(Request.Form["Choix"]);
            

            foreach (string getCheckedOuPas in Choix)
            {
                if (getCheckedOuPas == "true")
                {
                    boolCheckedOuPas = true;
                    CheckedOuPas.Add(boolCheckedOuPas);
                }
                else
                {
                    boolCheckedOuPas = false;
                    CheckedOuPas.Add(boolCheckedOuPas);

                }

            }

            return View("Vote");
        }


        
    }
}