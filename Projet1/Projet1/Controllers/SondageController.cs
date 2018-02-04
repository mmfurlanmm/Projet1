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

            int choixVide = 0;

            for (int i = 0; i < Choix.Count; i++)
            {
                if (Choix[i] == "")
                {
                    choixVide++;
                }
            }


            if (question == ""||choixVide>2)
            {
                return View("NbQuestionEtChoixMin");
            }
            else
            {


                bool choixMultiple;
                if (check == "checked")
                { choixMultiple = true; }
                else choixMultiple = false;


                Choix.RemoveAll(string.IsNullOrEmpty);
                Sondage NouveauSondage = new Sondage(question, Choix, choixMultiple);

                ViewBag.dernierIDBDD = SQL.SauvegarderEnBDD(NouveauSondage); //Appel de la méthode permettant de sauvegarder le sondage dans la BDD
                                                                             //et récupération du dernier ID du sondage
                Guid cleDesactivation = Guid.NewGuid();
                cleDesactivation.ToString();

                ViewBag.cleDesactivation = cleDesactivation;


                return View("SondageCree");
            }

        }

        public ActionResult Sondage(int Id)
        {
            ViewBag.idSondage = Id;

            QuestionEtChoix QuestionEtChoixBDD = SQL.GetQuestionEtChoix(Id);
            if (QuestionEtChoixBDD.sondageActif == true)
            {
                return View("Sondage", QuestionEtChoixBDD);
            }
            else
            {
                return View("SondageDesactive");
            }

        }



        public ActionResult Voter(int idSondage, List<int> ChoixSondage)
        {
            ViewBag.idSondage = idSondage;

            if (ChoixSondage != null)
            {
                HttpCookie MyCookie = Request.Cookies[idSondage.ToString()];

                if (MyCookie == null)
                {

                    MyCookie = new HttpCookie(idSondage.ToString());
                    //Response.Cookies.Add(MyCookie);
                    SQL.Voter(idSondage, ChoixSondage);
                    return View("Vote");
                }
                else
                {
                    return View("DejaVote");
                }


            }
            else
            {
                return View("Erreur");
            }

        }

        public ActionResult Resultats(int Id)
        {
            ResultatsSondage ResultatsBDD = SQL.GetResultats(Id);

            int nbDeVotesTotal = 0;

            foreach (int nb in ResultatsBDD.NbDeVotantsParChoix)
            {
                nbDeVotesTotal += nb;
            }

            ViewBag.nbDeVotesTotal = nbDeVotesTotal;

            return View("Resultat", ResultatsBDD);
        }

        public ActionResult SondageDesactive(int Id, string Key)
        {
            SQL.DesactivationSondage(Id);

            return View("SondageSupprime");
        }

    }
}