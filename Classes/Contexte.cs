using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Contexte : DbContext
    {
        public Contexte() : base("name=ProjetConnexionString")
        {

        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
