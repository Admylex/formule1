using Projet.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Projet.DAL
{
    public class F1Context : DbContext
    {

        public F1Context() : base("F1Context")
        {
        }

        public DbSet<Pilote> Pilotes { get; set; }
        public DbSet<Ecurie> Ecuries{ get; set; }
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<Resultat> Resultats { get; set; }

        public System.Data.Entity.DbSet<Projet.Models.Point> Points { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public IEnumerable<object> Admin { get; internal set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}