using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.Projet.Models
{
    public class ClasseViewModel
    {
        public int ID { get; set; }
        public string Niveau { get; set; }
        public string Nom { get; set; }
        public List<Eleve> Eleves { get; set; }
    }
}