using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class Sondage
    {
        public int IdSondage { get; set; }
        public bool ChoixMultiple { get; set; }
        public string Question { get; set; }
        public int NbVotants { get; set; }
        public string LienSuppression { get; set; }
        public string LienResultat { get; set; }
        public string LienPartage { get; set; }
        public bool SondageActif { get; set; }

    }
}