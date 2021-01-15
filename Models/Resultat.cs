using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet.Models
{
    public class Resultat
    {
        public int ResultatID { get; set; }
        [ForeignKey("pilote")]
        public int PiloteID { get; set; }
        public virtual Pilote pilote { get; set; }
        [ForeignKey("circuit")]
        public int CircuitID { get; set; }
        public virtual Circuit circuit { get; set; }
        public int Position { get; set; }
        public bool MT { get; set; }
        [ForeignKey("point")]
        public int PointID { get; set; }
        public virtual Point point { get; set; }
    }
}