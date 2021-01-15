using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet.Models
{
    public class Ecurie
    {
        public int EcurieID { get; set; }
        public String Nom_e { get; set; }
        public String Nationalite_e { get; set; }
        public virtual ICollection<Pilote> Pilotes { get; set; }
    }
}