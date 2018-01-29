using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class SondageEtQuestions
    {
        public string Question { get; set; }
        /*public string Choix1 { get; set; }
        public string Choix2 { get; set; }
        public string Choix3 { get; set; }
        public string Choix4 { get; set; }*/
        public List<string> Choix { get; set; }
         

    
    }
}