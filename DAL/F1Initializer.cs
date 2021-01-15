using Projet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Projet.DAL
{
    public class F1Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<F1Context>
    {
        protected override void Seed(F1Context context)
        {
           var ecuries = new List<Ecurie>
            {
                new Ecurie{Nom_e="Mercedes",Nationalite_e="Allemand"},
                new Ecurie{Nom_e="Ferrari",Nationalite_e="Italien"},
                new Ecurie{Nom_e="RedBull",Nationalite_e="Autrichien"},
                new Ecurie{Nom_e="Renault",Nationalite_e="Français"},
                new Ecurie{Nom_e="Mclaren",Nationalite_e="Anglais"},
                new Ecurie{Nom_e="Alpha Tauri",Nationalite_e="Italien"},
                new Ecurie{Nom_e="Haas",Nationalite_e="Americain"},
                new Ecurie{Nom_e="Racing Point",Nationalite_e="Anglais"},
                new Ecurie{Nom_e="Alpha Romeo",Nationalite_e="Italien"},
                new Ecurie{Nom_e="Williams",Nationalite_e="Anglais"},
                 

            };
            ecuries.ForEach(e => context.Ecuries.Add(e));
            context.SaveChanges();

            var pilotes = new List<Pilote>
            {
                new Pilote{Numero=77,Nom="Bottas",Prenom="Valteri",Nat="Finlandais",Date_Naissance=DateTime.Parse("1989-08-28"),IDEcurie =1},
                new Pilote{Numero=44,Nom="Hamilton",Prenom="Lewis",Nat="Anglais",Date_Naissance=DateTime.Parse("1988-01-07"),IDEcurie =1},
                new Pilote{Numero=5,Nom="Vettel",Prenom="Sebastian",Nat="Allemand",Date_Naissance=DateTime.Parse("1987-07-03"),IDEcurie =2},
                new Pilote{Numero=16,Nom="Leclerc",Prenom="Charles",Nat="Monégasque",Date_Naissance=DateTime.Parse("1997-10-16"),IDEcurie =2},
                new Pilote{Numero=33,Nom="Verstappen",Prenom="Max",Nat="Hollandais",Date_Naissance=DateTime.Parse("1997-09-30"),IDEcurie =3},
                new Pilote{Numero=23,Nom="Albon",Prenom="Alexander",Nat="Thailandais",Date_Naissance=DateTime.Parse("1996-03-23"),IDEcurie =3},
                new Pilote{Numero=3,Nom="Ricciardo",Prenom="Daniel",Nat="Australien",Date_Naissance=DateTime.Parse("1989-08-21"),IDEcurie =4},
                new Pilote{Numero=31,Nom="Ocon",Prenom="Esteban",Nat="Français",Date_Naissance=DateTime.Parse("1996-09-17"),IDEcurie =4},
                new Pilote{Numero = 4, Nom = "Norris", Prenom = "Lando", Nat = "Anglais", Date_Naissance = DateTime.Parse("1999-11-13"), IDEcurie = 5},
                new Pilote{Numero = 55, Nom = "Sainz", Prenom = "Carlos", Nat = "Espagnol", Date_Naissance = DateTime.Parse("1994-09-01"), IDEcurie = 5},
                new Pilote{Numero = 18, Nom = "Stroll", Prenom = "Lance", Nat = "Canadien", Date_Naissance = DateTime.Parse("1998-10-29"), IDEcurie = 6},
                new Pilote{Numero = 11, Nom = "Perez", Prenom = "Sergio", Nat = "Mexicain", Date_Naissance = DateTime.Parse("1990-01-26"), IDEcurie = 6},
                new Pilote{Numero = 26, Nom = "Kvyat", Prenom = "Daniil", Nat = "Russe", Date_Naissance = DateTime.Parse("1994-04-26"), IDEcurie = 7},
                new Pilote{Numero = 10, Nom = "Gasly", Prenom = "Pierre", Nat = "Français", Date_Naissance = DateTime.Parse("1996-02-07"), IDEcurie = 7},
                new Pilote{Numero = 7, Nom = "Raïkkönen", Prenom = "Kimi", Nat = "Finlandais", Date_Naissance = DateTime.Parse("1979-10-17"), IDEcurie = 8},
                new Pilote{Numero = 99, Nom = "Giovinazzi", Prenom = "Antonio", Nat = "Italien", Date_Naissance = DateTime.Parse("1993-12-14"), IDEcurie = 8},
                new Pilote{Numero = 20, Nom = "Magnussen", Prenom = "Kevin", Nat = "Danois", Date_Naissance = DateTime.Parse("1992-10-05"), IDEcurie = 9},
                new Pilote{Numero = 8, Nom = "Grosjean", Prenom = "Romain", Nat = "Français", Date_Naissance = DateTime.Parse("1986-04-17"), IDEcurie = 9},
                new Pilote{Numero = 6, Nom = "Latifi", Prenom = "Nicholas", Nat = "Canadien", Date_Naissance = DateTime.Parse("1995-06-29"), IDEcurie = 10},
                new Pilote{Numero = 63, Nom = "Russel", Prenom = "Georges", Nat = "Anglais", Date_Naissance = DateTime.Parse("1998-02-15"), IDEcurie = 10}

        };
            pilotes.ForEach(p => context.Pilotes.Add(p));
            context.SaveChanges();

            var circuits = new List<Circuit>
            {
                new Circuit{Nom_c="Circuit de Spa-Francorchamps",Ville="Spa",Pays="Belgique"},
                new Circuit{Nom_c="Autodromo Nazionale di Monza",Ville="Monza",Pays="Italie "},
                new Circuit{Nom_c="Red Bull Ring",Ville="Spielburg",Pays="Autriche"},
                new Circuit{Nom_c="Silverstone Circuit",Ville="Silverstone",Pays="UK"},
                new Circuit{Nom_c="Sochi Autodrom",Ville="Sochi",Pays="Russie"},
                new Circuit{Nom_c="HUNGARORING",Ville="Budapest",Pays="Hongrie"},
                new Circuit{Nom_c="CIRCUIT DE BARCELONA-CATALUNYA",Ville="Barcelone",Pays="Espagne"},
                new Circuit{Nom_c="MUGELLO",Ville="Mugello",Pays="Italie"},
                new Circuit{Nom_c="NÜRBURGRING",Ville="Nürburg",Pays="Allemagne"},
                new Circuit{Nom_c="AUTÓDROMO INTERNACIONAL DO ALGARVE",Ville="Portimão",Pays="Portugal"},
                new Circuit{Nom_c="AUTODROMO ENZO E DINO FERRARI",Ville="Imola",Pays="Italie"},
                new Circuit{Nom_c="INTERCITY ISTANBUL PARK",Ville="Istanbul",Pays="Turquie"},
                new Circuit{Nom_c="BAHRAIN INTERNATIONAL CIRCUIT",Ville="Sakhir",Pays="Bahrain"},
                new Circuit{Nom_c="YAS MARINA CIRCUIT",Ville="Abu Dhabi",Pays="Emirat Arabes Unis"}
            };
            circuits.ForEach(c => context.Circuits.Add(c));
            context.SaveChanges();

        }
    }

}