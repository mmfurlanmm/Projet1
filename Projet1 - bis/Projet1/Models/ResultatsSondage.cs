using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet1.Models
{
    public class ResultatsSondage
    {
        public int nbDeVotantsTotal { get; set; }
        public List<int> NbDeVotantsParChoix { get; set; }
        public string question { get; set; }
        public List<string> IntituleChoix { get; set; }

        public ResultatsSondage(int _nbDeVotantsTotal, List<int> _NbDeVotantsParChoix, string _question, List<string>_IntituleChoix)
        {
            nbDeVotantsTotal = _nbDeVotantsTotal;
            NbDeVotantsParChoix = _NbDeVotantsParChoix;
            question = _question;
            IntituleChoix = _IntituleChoix;
        }

    }
}