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
        //Afficher la vue de création d'un sondage
        public ActionResult CreerSondage()
        {
            return View("CreerSondage");
        }


        //Enregistrement d'un sondage dans la BDD
        public ActionResult SondageCree(string question, List<string> Choix, string check)
        {

            //Les choix vides sont effacés de la liste "Choix" avant qu'elle ne soit enregistrée dans la BDD
            Choix.RemoveAll(string.IsNullOrEmpty);

            //Le FOR et le IF suivants empêchent la création d'un sondage 
            //si le champ "QUESTION" est vide ou si l'utilisateur n'entre pas au moins 2 choix
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
                return View("NbQuestionEtChoixMin"); //Si les conditions précédentes ne sont pas remplies, 
            }                                        //l'utilisateur est renvoyé vers une page d'erreur
            else
            {

                //Vérifie si les choix multiples sont autorisés pour le sondage
                bool choixMultiple;
                if (check == "checked")
                { choixMultiple = true; }
                else choixMultiple = false;

                Guid generationCleDesactivation = Guid.NewGuid(); //Génération d'une valeur aléatoire de type Guid pour le lien de désactivation du sondage
                string cleDesactivation = generationCleDesactivation.ToString(); //Convertie la valeur du Guid en string

                
                Sondage NouveauSondage = new Sondage(question, Choix, choixMultiple, cleDesactivation);

                ViewBag.dernierIDBDD = SQL.SauvegarderEnBDD(NouveauSondage); //Appel de la méthode permettant de sauvegarder le sondage dans la BDD
                                                                             //et récupération de l'ID du sondage en cours

                

                ViewBag.cleDesactivation = cleDesactivation;


                return View("SondageCree");
            }

        }

        public ActionResult Sondage(int Id)
        {
            ViewBag.idSondage = Id;

            // On vérifie si le sondage n'a pas été précédemment désactivé
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

            if (ChoixSondage != null) //Permet de vérifier que l'utilisateur a sélectionné au moins une réponse
            {
                HttpCookie MyCookie = Request.Cookies[idSondage.ToString()]; //Verifie la présence de l'id du sondage en string dans le Cookie

                if (MyCookie == null)
                {

                    MyCookie = new HttpCookie(idSondage.ToString()); //Si le vote de l'utilisateur est possible, génération d'un cookie,
                                                                     //besoin d'une conversion de l'id du sondage en string
                    Response.Cookies.Add(MyCookie); //Ajout du cookie dans le navigateur de l'utilisateur
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
                        
            return View("Resultat", ResultatsBDD);
        }

        public ActionResult SondageDesactive(int Id, string key)
        {
            string keyBDD = SQL.VerificationCleDesactivation(Id, key);

            if(keyBDD == key)
            {
                SQL.DesactivationSondage(Id);

                return View("SondageSupprime");
            }
            else
            {
                
                return View("ErreurSondageSupprime");
            }
            
        }

    }
}