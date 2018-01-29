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

        
        
        
        //Mise en place d'un nouveau sondage. Dans cette vue, l'utilisateur peut voter et soumettre son vote
        public ActionResult Sondage(string question, string choix1, string choix2, string choix3, string choix4)
        {
            SondageEtQuestions NouveauSondage = new SondageEtQuestions();
            NouveauSondage.Question = question;
            NouveauSondage.Choix = new List<string>();

            List<string> recupererChoix = new List<string> { choix1, choix2, choix3, choix4 };
            foreach(string insererDansListe in recupererChoix)
            {
                if(!string.IsNullOrEmpty(insererDansListe))
                {
                    NouveauSondage.Choix.Add(insererDansListe);

                }
                
            }
          

            // SauvegarderEnBDD(NouveauSondage); //Appel de la méthode permettant de sauvegarder dans la BDD

            return View(NouveauSondage);
        }

        /*private const string SqlConnectionString =
            @"Server=.\SQLExpress;Initial Catalog=SondageBDD; Trusted_Connection=Yes";

        
        
        
        //Méthode permettant de sauvegarder la question et les choix dans leur BDD respective
        static void SauvegarderEnBDD(SondageEtQuestions sondageASauvegarder)
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand insertSondage = new SqlCommand(
                @"INSERT INTO Sondage(Question) VALUES (@question)", connexion);
            insertSondage.Parameters.AddWithValue("@question", sondageASauvegarder.Question);
            insertSondage.ExecuteNonQuery();

            //Récupération de l'ID correspondant à la question. Il est utilisé pour la clé étrangère de la table ChoixPossibles
            SqlCommand getID = new SqlCommand(
                @"SELECT MAX(IdSondage) FROM Sondage", connexion);
            int dernierID = (int)getID.ExecuteScalar();

            SqlCommand insertChoixPossibles1 = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
            insertChoixPossibles1.Parameters.AddWithValue("@choix", sondageASauvegarder.Choix1);
            insertChoixPossibles1.Parameters.AddWithValue("@fk", dernierID);
            insertChoixPossibles1.ExecuteNonQuery();

            SqlCommand insertChoixPossibles2 = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
            insertChoixPossibles2.Parameters.AddWithValue("@choix", sondageASauvegarder.Choix2);
            insertChoixPossibles2.Parameters.AddWithValue("@fk", dernierID);
            insertChoixPossibles2.ExecuteNonQuery();

            SqlCommand insertChoixPossibles3 = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
            insertChoixPossibles3.Parameters.AddWithValue("@choix", sondageASauvegarder.Choix3);
            insertChoixPossibles3.Parameters.AddWithValue("@fk", dernierID);
            insertChoixPossibles3.ExecuteNonQuery();

            SqlCommand insertChoixPossibles4 = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
            insertChoixPossibles4.Parameters.AddWithValue("@choix", sondageASauvegarder.Choix4);
            insertChoixPossibles4.Parameters.AddWithValue("@fk", dernierID);
            insertChoixPossibles4.ExecuteNonQuery();

            connexion.Close();

        }*/
    }
}