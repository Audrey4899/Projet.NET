using Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.Projet.Models
{
    public class EleveViewModel
    {
        //public string NameSearch { get; set; }
        public int ID { get; set; }
        public string Identite { get; set; }
        public List<Note> Notes { get; set; }
        public List<Absence> Absences { get; set; }
    }
}