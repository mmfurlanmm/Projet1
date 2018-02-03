using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class QuestionEtChoix
    {
        public string Question { get; set; }
        public List<string> Choix { get; set; }
        public List<int> IdChoix { get; set; }
        public int Idsondage { get; set; }
        public bool choixMultiple { get; set; }


        public QuestionEtChoix(string _Question, List<string> _Choix, List<int> _IdChoix, int _IdSondage, bool _choixMultiple)
        {
            Question = _Question;
            Choix = _Choix;
            IdChoix = _IdChoix;
            Idsondage = _IdSondage;
            choixMultiple = _choixMultiple;
            
        }
         

    
    }
}