using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET.Projet.Models
{
    public class NoteViewModel
    {
        public int ID { get; set; }
        public string Matiere { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        public int Note { get; set; }
        public string Appreciation { get; set; }
    }
}