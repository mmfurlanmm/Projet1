using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace Projet1.Models
{
    public class SQL
    {
        private const string SqlConnectionString =
            @"Server=.\SQLExpress;Initial Catalog=SondageBDD; Trusted_Connection=Yes";


        //Méthode permettant de sauvegarder la question et les choix dans leur BDD respective
        public static void SauvegarderEnBDD(Sondage sondageASauvegarder)
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand insertSondage = new SqlCommand(
                @"INSERT INTO Sondage(Question, ChoixMultiple) VALUES (@question, @choixMultiple)", connexion);
            insertSondage.Parameters.AddWithValue("@question", sondageASauvegarder.Question);
            insertSondage.Parameters.AddWithValue("@choixMultiple", sondageASauvegarder.ChoixMultiple);

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
        public static Sondage RecupererDansBDD()
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand getID = new SqlCommand(
                @"SELECT MAX(IdSondage) FROM Sondage", connexion);
            int dernierID = (int)getID.ExecuteScalar();

            SqlCommand getQuestion = new SqlCommand(
                @"SELECT Question FROM Sondage WHERE IdSondage = @dernierId", connexion);
            getQuestion.Parameters.AddWithValue("@dernierId", dernierID);
            string questionBDD = (string)getQuestion.ExecuteScalar();

            SqlCommand getChoixMultiple = new SqlCommand(
                @"SELECT ChoixMultiple FROM Sondage WHERE IdSondage = @dernierId", connexion);
            getChoixMultiple.Parameters.AddWithValue("@dernierId", dernierID);
            bool choixMultipleBDD = (bool)getChoixMultiple.ExecuteScalar();


            SqlCommand getChoix = new SqlCommand(
            @"SELECT IntituleChoix FROM ChoixPossibles WHERE FkIdSondage=@dernierId", connexion);
            getChoix.Parameters.AddWithValue("@dernierId", dernierID);
            SqlDataReader reader = getChoix.ExecuteReader();
            List<string> ChoixDansBDD = new List<string>();


            while (reader.Read())
            {
                ChoixDansBDD.Add((string)reader["IntituleChoix"]);
            }

            Sondage QuestionEtChoixBDD = new Sondage(questionBDD, ChoixDansBDD, choixMultipleBDD);



            connexion.Close();

            return QuestionEtChoixBDD;
        }
    }
}