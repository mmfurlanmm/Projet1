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
        

        public QuestionEtChoix(string _Question, List<string> _Choix)
        {
            Question = _Question;
            Choix = _Choix;
            
        }
         

    
    }
}