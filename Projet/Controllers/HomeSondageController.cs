using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
//using Projet.Models

namespace Projet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


        private const string SqlConnectionString =
@"Server=.\SQLExpress;Initial Catalog=SondageBDD; Trusted_Connection=Yes";

        public ActionResult Index()
        {
            SqlConnection connexion = new SqlConnection(SqlConnectionString);
            connexion.Open();

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Sondage (ChoixMultiple,Question,NbVotants,LienSuppression,LienResultat,LienPartage,SondageActif) VALUES (@ChoixMultiple,@Question,@NbVotants,@LienSuppression,@LienResultat,@LienPartage,@SondageActif)", connexion);
            var ChoixMultiple = new SqlParameter("@ChoixMultiple", "0");
            var Question = new SqlParameter("@Question", "DeuxLaQuestion");
            var NbVotants = new SqlParameter("@NbVotants", "30");
            var LienSuppression = new SqlParameter("@LienSuppression", "leLienSuppression");
            var LienResultat = new SqlParameter("@LienResultat", "leLienResultat");
            var LienPartage = new SqlParameter("@LienPartage", "leLienPartage ");
            var SondageActif = new SqlParameter("@SondageActif", "0");

            sqlCommand.Parameters.Add(ChoixMultiple);
            sqlCommand.Parameters.Add(Question);
            sqlCommand.Parameters.Add(NbVotants);
            sqlCommand.Parameters.Add(LienSuppression);
            sqlCommand.Parameters.Add(LienResultat);
            sqlCommand.Parameters.Add(LienPartage);
            sqlCommand.Parameters.Add(SondageActif);
            sqlCommand.ExecuteNonQuery();
            
            
            SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO ChoixPossibles (IntituleChoix, NbVotantsParChoix, FkIdSondage) VALUES (@IntituleChoix, @NbVotantsParChoix, @FkIdSondage)", connexion);

            var IntituleChoix = new SqlParameter("@IntituleChoix", "PremierChoix");
     //       var NbVotantsParChoix = new SqlParameter("@NbVotantsParChoix", "30");
            var FkIdSondage = new SqlParameter("@FkIdSondage", "1");

            sqlCommand2.Parameters.AddWithValue("@IntituleChoix", "TroisièmeChoix");
            sqlCommand2.Parameters.AddWithValue("@NbVotantsParChoix", "200");
            sqlCommand2.Parameters.Add(FkIdSondage);
            sqlCommand2.ExecuteNonQuery();
            
            //
            // TODO: faire requete SQL avec boucle pour liste (avec ajout dynamique) 
            //


            SqlCommand sqlCommand3 = new SqlCommand("INSERT INTO ChoixPossibles (IntituleChoix, NbVotantsParChoix, FkIdSondage) VALUES (@IntituleChoix, @NbVotantsParChoix, @FkIdSondage)", connexion);
            

            var IntituleChoix2 = new SqlParameter("@IntituleChoix", "SecondChoix");
            var NbVotantsParChoix2 = new SqlParameter("@NbVotantsParChoix", "30");
            var FkIdSondage2 = new SqlParameter("@FkIdSondage", "1");


            sqlCommand3.Parameters.Add(IntituleChoix2);
            sqlCommand3.Parameters.Add(NbVotantsParChoix2);
            sqlCommand3.Parameters.Add(FkIdSondage2);
            sqlCommand3.ExecuteNonQuery();



            connexion.Close();

            return View("Resultat");
        }
    }
}
 