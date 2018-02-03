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
                                
            ViewBag.dernierIDBDD = SQL.SauvegarderEnBDD(NouveauSondage); //Appel de la méthode permettant de sauvegarder dans la BDD
                                                                              //et récupération du dernier ID du sondage


            /*
            HttpCookie MyCookie = new HttpCookie("LastVisit");
            MyCookie.Value = "la Valeur du cookie";

            Response.Cookies.Add(MyCookie);*/


            return View("SondageCree");


          
        }

        public ActionResult Sondage(int Id)
        {
            
            QuestionEtChoix QuestionEtChoixBDD = SQL.GetQuestionEtChoix(Id);

            return View("Sondage", QuestionEtChoixBDD);
        }



        public ActionResult Voter(int idSondage, List<int> ChoixSondage)
        {
            SQL.Voter(idSondage, ChoixSondage);
            
            ViewBag.idSondage = idSondage;
            
            

            return View("Vote");
        }

        public ActionResult Resultats(int idSondage)
        {
            ResultatsSondage ResultatsBDD = SQL.GetResultats(idSondage);

            int nbDeVotesTotal = 0;

            foreach (int nb in ResultatsBDD.NbDeVotantsParChoix)
            {
                nbDeVotesTotal+= nb;
            }

            ViewBag.nbDeVotesTotal = nbDeVotesTotal;

            return View("Resultat", ResultatsBDD);
        }


        
    }
}