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
            @"Server=172.19.240.3;Initial Catalog=SondageBDD; Trusted_Connection=Yes";
        private static SqlConnection connexion = new SqlConnection(SqlConnectionString);


        //Méthode permettant de sauvegarder la question et les choix dans leur BDD respective
        public static int SauvegarderEnBDD(Sondage sondageASauvegarder)
        {

            connexion.Open();

            //On entre la question dans la BDD et on en profite pour récupérer l'ID du sondage grâce à SCOPE_IDENTITY()
            SqlCommand insertSondage = new SqlCommand(
                @"INSERT INTO Sondage(Question, ChoixMultiple, LienSuppression) VALUES (@question, @choixMultiple, @lienSuppression);
                SELECT CAST(SCOPE_IDENTITY() as int);", connexion); //Le CAST() est nécessaire pour que l'ID soit récupéré dans le bon type (conversion de NUMERIC du SQL vers INT)
            insertSondage.Parameters.AddWithValue("@question", sondageASauvegarder.Question);
            insertSondage.Parameters.AddWithValue("@lienSuppression", sondageASauvegarder.LienSuppression);
            insertSondage.Parameters.AddWithValue("@choixMultiple", sondageASauvegarder.ChoixMultiple);

            int dernierID = (int)insertSondage.ExecuteScalar();

            connexion.Close();

            connexion.Open();

            //Insertion des choix dans la base de données avec une boucle
            foreach (string choixASauvegarder in sondageASauvegarder.Choix)
            {
                SqlCommand insertChoixPossibles = new SqlCommand(
                @"INSERT INTO ChoixPossibles (IntituleChoix, FkIdSondage) VALUES (@choix, @fk)", connexion);
                insertChoixPossibles.Parameters.AddWithValue("@choix", choixASauvegarder);
                insertChoixPossibles.Parameters.AddWithValue("@fk", dernierID);

                insertChoixPossibles.ExecuteNonQuery();
            }

            connexion.Close();

            connexion.Open();

            //On initialise le nombre de votants à 0 car on ne peut pas incrémenter une valeur nulle
            SqlCommand setAZero = new SqlCommand(
            @"UPDATE ChoixPossibles SET NbVotantsParChoix = 0 WHERE FkIdSondage = @dernierId
              UPDATE Sondage SET NbVotants = 0 WHERE IdSondage = @dernierId", connexion);
            setAZero.Parameters.AddWithValue("@dernierID", dernierID);
            setAZero.ExecuteNonQuery();

            connexion.Close();

            connexion.Open();

            //Tout sondage créé est initialé comme actif grace a un booleen 
            SqlCommand sondageActive = new SqlCommand(
            @"UPDATE Sondage SET SondageActif = 1 WHERE IdSondage = @dernierId", connexion);
            sondageActive.Parameters.AddWithValue("@dernierID", dernierID);
            sondageActive.ExecuteNonQuery();

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

            connexion.Close();

            connexion.Open();

            SqlCommand GetChoixMultiple = new SqlCommand(
                @"SELECT ChoixMultiple FROM Sondage WHERE IdSondage = @Id", connexion);
            GetChoixMultiple.Parameters.AddWithValue("@Id", Id);
            bool choixMultipleBDD = (bool)GetChoixMultiple.ExecuteScalar();

            connexion.Close();

            connexion.Open();

            SqlCommand GetSondageActif = new SqlCommand(
                @"SELECT SondageActif FROM Sondage WHERE IdSondage = @Id", connexion);
            GetSondageActif.Parameters.AddWithValue("@Id", Id);
            bool sondageActifBDD = (bool)GetSondageActif.ExecuteScalar();

            connexion.Close();

            connexion.Open();

            SqlCommand GetNbVotants = new SqlCommand(
                @"SELECT NbVotants FROM Sondage WHERE IdSondage = @Id", connexion);
            GetNbVotants.Parameters.AddWithValue("@Id", Id);
            int nbVotantsBDD = (int)GetNbVotants.ExecuteScalar();

            connexion.Close();

            //On envoie les données prélévées dans la BDD vers le modèle QuestionEtChoix
            QuestionEtChoix QuestionEtChoixBDD = new QuestionEtChoix(question, LIntituleChoix, LIdChoix, IdSondageBDD, choixMultipleBDD, sondageActifBDD, nbVotantsBDD);

            return QuestionEtChoixBDD;

        }

        public static void Voter(int idSondage, List<int> IdChoix)
        {
            connexion.Open();

            //Incrémentation du nombre de votants lorsque l'utilisateur vote
            SqlCommand IncrementerNbVotant = new SqlCommand(
                @"UPDATE Sondage SET NbVotants = NbVotants+1
                                       WHERE IdSondage = @idSondage", connexion);
            IncrementerNbVotant.Parameters.AddWithValue("@idSondage", idSondage);
            IncrementerNbVotant.ExecuteNonQuery();

            connexion.Close();

            connexion.Open();
            
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
           @"SELECT NbVotantsParChoix FROM ChoixPossibles WHERE FKIdSondage = @Id ORDER BY NbVotantsParChoix DESC", connexion);
            GetNbDeVotantsParChoix.Parameters.AddWithValue("@Id", id);
            SqlDataReader readerNbDeVotantsParChoix = GetNbDeVotantsParChoix.ExecuteReader();

            List<int> LNbDeVotantsParChoix = new List<int>();

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
                @"SELECT IntituleChoix FROM ChoixPossibles WHERE FKIdSondage = @Id ORDER BY NbVotantsParChoix DESC", connexion);
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

        public static void DesactivationSondage(int Id)
        {
            connexion.Open();

            SqlCommand sondageDesactive = new SqlCommand(
            @"UPDATE Sondage SET SondageActif = 0 WHERE IdSondage = @Id", connexion);
            sondageDesactive.Parameters.AddWithValue("@Id", Id);
            sondageDesactive.ExecuteNonQuery();

            connexion.Close();

        }

        public static string VerificationCleDesactivation(int id, string key)
        {
            connexion.Open();

            SqlCommand recuperationCleDesactivation = new SqlCommand(
            @"SELECT LienSuppression FROM Sondage WHERE IdSondage = @Id", connexion);
            recuperationCleDesactivation.Parameters.AddWithValue("@Id", id);
            string keyBDD = (string)recuperationCleDesactivation.ExecuteScalar();

            connexion.Close();

            return keyBDD;
        }
    }
}