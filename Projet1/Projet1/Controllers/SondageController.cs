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


        private const string SqlConnectionString =
           @"Server=.\SQLExpress;Initial Catalog=SondageBDD; Trusted_Connection=Yes";
        // Afficher la vue de création d'un sondage
        public ActionResult CreerSondage()
        {
            return View("CreerSondage");
        }

        
        
        
        //Enregistrement d'un sondage dans la BDD
        public ActionResult SondageCree(string question, List<string> Choix)
        {

            Choix.RemoveAll(string.IsNullOrEmpty);
            QuestionEtChoix NouveauSondage = new QuestionEtChoix(question, Choix);
                    
            SauvegarderEnBDD(NouveauSondage); //Appel de la méthode permettant de sauvegarder dans la BDD


            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            // Génération du cookie
            SqlCommand getID = new SqlCommand(
                @"SELECT MAX(IdSondage) FROM Sondage", connexion);
            
            int dernierID = (int)getID.ExecuteScalar();

            string dernierIdStr = dernierID.ToString();

            HttpCookie MyCookie = new HttpCookie("VoteSondage");
            MyCookie.Value = dernierIdStr;

            Response.Cookies.Add(MyCookie);

            connexion.Close();

            return View("SondageCree");

            
          
        }

        public ActionResult Sondage()
        {
            QuestionEtChoix SondageBDD = new QuestionEtChoix(RecupererDansBDD().Question, RecupererDansBDD().Choix);


            /*
           HttpCookie MyCookie = new HttpCookie("LastVisit");
           MyCookie.Value = "la Valeur du cookie";

           Response.Cookies.Add(MyCookie);*/

            return View(SondageBDD);
        }


       
        
        
        //Méthode permettant de sauvegarder la question et les choix dans leur BDD respective
        static void SauvegarderEnBDD(QuestionEtChoix sondageASauvegarder)
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

            //Insertion des choix dans la base de données avec une boucle
            foreach (string choixASauvegarder in sondageASauvegarder.Choix)
            {
                SqlCommand insertChoixPossibles1 = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
                insertChoixPossibles1.Parameters.AddWithValue("@choix", choixASauvegarder);
                insertChoixPossibles1.Parameters.AddWithValue("@fk", dernierID);
                insertChoixPossibles1.ExecuteNonQuery();
            }
                       
            connexion.Close();

        }

        //Récupération du sondage dans les bases de données
        static QuestionEtChoix RecupererDansBDD()
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand getID = new SqlCommand(
                @"SELECT MAX(IdSondage) FROM Sondage", connexion);
            int dernierID = (int)getID.ExecuteScalar();

            SqlCommand getQuestion = new SqlCommand(
                @"SELECT Question FROM Sondage WHERE IdSondage = @dernierId", connexion);
            getQuestion.Parameters.AddWithValue("@dernierId", dernierID);
            string questionBDD= (string)getQuestion.ExecuteScalar();

            SqlCommand getChoix = new SqlCommand(
            @"SELECT IntituleChoix FROM ChoixPossibles WHERE FkIdSondage=@dernierId", connexion);
            getChoix.Parameters.AddWithValue("@dernierId", dernierID);
            SqlDataReader reader = getChoix.ExecuteReader();
            List<string> ChoixDansBDD = new List<string>();
            

            while (reader.Read())
            {
                ChoixDansBDD.Add((string)reader["IntituleChoix"]);
            }

            QuestionEtChoix QuestionEtChoixBDD = new QuestionEtChoix(questionBDD, ChoixDansBDD);
            
                        
            
            connexion.Close();

            return QuestionEtChoixBDD;
        }
    }
}