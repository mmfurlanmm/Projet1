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
        private static SqlConnection connexion = new SqlConnection(SqlConnectionString);


        //Méthode permettant de sauvegarder la question et les choix dans leur BDD respective
        public static int SauvegarderEnBDD(Sondage sondageASauvegarder)
        {
            
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
                SqlCommand insertChoixPossibles = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
                insertChoixPossibles.Parameters.AddWithValue("@choix", choixASauvegarder);
                insertChoixPossibles.Parameters.AddWithValue("@fk", dernierID);
                insertChoixPossibles.ExecuteNonQuery();
            }

            SqlCommand setAZero = new SqlCommand(
            @"UPDATE ChoixPossibles SET NbVotantsParChoix = 0 WHERE FkIdSondage = @dernierId
              UPDATE Sondage SET NbVotants = 0 WHERE IdSondage = @dernierId", connexion);
            setAZero.Parameters.AddWithValue("dernierID", dernierID);
            setAZero.ExecuteNonQuery();



            connexion.Close();

            return dernierID;

            

        }
        
        

        
        public static QuestionEtChoix GetQuestionEtChoix(int Id)
        {
            connexion.Open();

            SqlCommand GetQuestion = new SqlCommand(
                @"SELECT Question FROM Sondage WHERE IdSondage = @Id", connexion);
            GetQuestion.Parameters.AddWithValue("@Id", Id);

            string question = (string)GetQuestion.ExecuteScalar();

            connexion.Close();

            connexion.Open();

            SqlCommand GetIdChoix = new SqlCommand(
                @"SELECT IdChoix FROM ChoixPossibles WHERE FkIdSondage = @Id", connexion);
            GetIdChoix.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = GetIdChoix.ExecuteReader();

            List<int> LIdChoix = new List<int>();

            while (reader.Read())
            {
                LIdChoix.Add((int)reader["IdChoix"]);
            }

            connexion.Close();

            connexion.Open();

            SqlCommand GetIntituleChoix = new SqlCommand(
                @"SELECT IntituleChoix FROM ChoixPossibles WHERE FKIdSondage = @Id", connexion);
            GetIntituleChoix.Parameters.AddWithValue("@Id", Id);
            SqlDataReader readerIntituleChoix = GetIntituleChoix.ExecuteReader();

            List<string> LIntituleChoix = new List<string>();

            while (readerIntituleChoix.Read())
            {
                LIntituleChoix.Add((string)readerIntituleChoix["IntituleChoix"]);
            }

            connexion.Close();

            connexion.Open();

            SqlCommand GetIdSondage = new SqlCommand(
                @"SELECT IdSondage FROM Sondage WHERE IdSondage = @Id", connexion);
            GetIdSondage.Parameters.AddWithValue("@Id", Id);

            int IdSondageBDD = (int)GetIdSondage.ExecuteScalar();

            SqlCommand GetChoixMultiple = new SqlCommand(
                @"SELECT ChoixMultiple FROM Sondage WHERE IdSondage = @Id", connexion);
            GetChoixMultiple.Parameters.AddWithValue("@Id", Id);
            bool choixMultipleBDD = (bool)GetChoixMultiple.ExecuteScalar();

            connexion.Close();

            QuestionEtChoix QuestionEtChoixBDD = new QuestionEtChoix(question, LIntituleChoix, LIdChoix, IdSondageBDD, choixMultipleBDD);

            return QuestionEtChoixBDD;
            
        }

        public static void Voter (int idSondage, List<int> IdChoix)
        {
            connexion.Open();
            SqlCommand IncrementerNbVotant = new SqlCommand(
                @"UPDATE Sondage SET NbVotants = NbVotants+1
                                       WHERE IdSondage = @idSondage", connexion);
            IncrementerNbVotant.Parameters.AddWithValue("@idSondage", idSondage);
            IncrementerNbVotant.ExecuteNonQuery();


            foreach (int choixDansListe in IdChoix)
            {
                SqlCommand IncrementerNbVotantParChoix = new SqlCommand(
                @"UPDATE ChoixPossibles SET NbVotantsParChoix = NbVotantsParChoix+1
                                       WHERE FkIdSondage = @idSondage AND IdChoix = @IdChoix", connexion);
                IncrementerNbVotantParChoix.Parameters.AddWithValue("@idSondage", idSondage);
                IncrementerNbVotantParChoix.Parameters.AddWithValue("@IdChoix", choixDansListe);
                IncrementerNbVotantParChoix.ExecuteNonQuery();

            }
            

            connexion.Close();
        }

        public static ResultatsSondage GetResultats(int id)
        {
            connexion.Open();

            SqlCommand GetNbDeVotantsTotal = new SqlCommand(
                @"SELECT NbVotants FROM Sondage WHERE IdSondage = @Id", connexion);
            GetNbDeVotantsTotal.Parameters.AddWithValue("@Id", id);
            int NbDeVotantsTotal = (int)GetNbDeVotantsTotal.ExecuteScalar();

            connexion.Close();

            connexion.Open();

            SqlCommand GetNbDeVotantsParChoix = new SqlCommand(
           @"SELECT NbVotantsParChoix FROM ChoixPossibles WHERE FKIdSondage = @Id", connexion);
            GetNbDeVotantsParChoix.Parameters.AddWithValue("@Id", id);
            SqlDataReader readerNbDeVotantsParChoix= GetNbDeVotantsParChoix.ExecuteReader();

            List<int> LNbDeVotantsParChoix= new List<int>();

            while (readerNbDeVotantsParChoix.Read())
            {
                LNbDeVotantsParChoix.Add((int)readerNbDeVotantsParChoix["NbVotantsParChoix"]);
            }
            connexion.Close();

            connexion.Open();

            SqlCommand GetQuestion = new SqlCommand(
                @"SELECT Question FROM Sondage WHERE IdSondage = @Id", connexion);
            GetQuestion.Parameters.AddWithValue("@Id", id);

            string question = (string)GetQuestion.ExecuteScalar();

            connexion.Close();

            connexion.Open();

            SqlCommand GetIntituleChoix = new SqlCommand(
                @"SELECT IntituleChoix FROM ChoixPossibles WHERE FKIdSondage = @Id", connexion);
            GetIntituleChoix.Parameters.AddWithValue("@Id", id);
            SqlDataReader readerIntituleChoix = GetIntituleChoix.ExecuteReader();

            List<string> LIntituleChoix = new List<string>();

            while (readerIntituleChoix.Read())
            {
                LIntituleChoix.Add((string)readerIntituleChoix["IntituleChoix"]);
            }

            connexion.Close();

            ResultatsSondage NbDeVotantsBDD = new ResultatsSondage(NbDeVotantsTotal, LNbDeVotantsParChoix, question, LIntituleChoix);

            return NbDeVotantsBDD;

        }
             
        
    }
}