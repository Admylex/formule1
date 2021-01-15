using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Projet.Models
{
    public class Pilote
    {
        public int PiloteID { get; set; }
        public int Numero { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Nat { get; set; }
        public DateTime Date_Naissance { get; set; }
        [ForeignKey("ecurie")]
        public int IDEcurie { get; set; }
        public virtual Ecurie ecurie { get; set; }
       
    }
  
}