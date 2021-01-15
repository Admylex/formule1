using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { set; get; }
        public String pseudo { set; get; }
        public String mdp { set; get; }
    }
}