using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class ChoixPossibles
    {
        public int IdChoix { get; set; }
        public string IntituleChoix { get; set; }
        public int NbVotantsParChoix { get; set; }
        public int FkIdSondage { get; set; }
    }
}