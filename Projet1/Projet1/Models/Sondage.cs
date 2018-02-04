using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Sondage
    {
        
        public string Question { get; set; }
        public List<string> Choix { get; set; }
        public bool ChoixMultiple { get; set; }
        public string LienSuppression { get; set; }
        public string LienResultat { get; set; }
        public string LienPartage { get; set; }
        public bool SondageActif { get; set; }
        public int NbVotantsParChoix { get; set; }

        public Sondage(string _Question, List<string> _Choix, bool _choixMultiple)
        {
            
            Question = _Question;
            Choix = _Choix;
            ChoixMultiple = _choixMultiple;
           

        }

    }
    


    
    

}