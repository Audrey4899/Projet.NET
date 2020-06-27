using Classes.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET.Projet.Models
{
    public class AbsenceViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Motif { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        public Eleve Eleve { get; set; }
    }
}