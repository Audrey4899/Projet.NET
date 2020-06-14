using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Entites
{
    [Table("Eleve")]
    public class Eleve
    {
        [Key]
        [Column("EleveId")]
        public int EleveId { get; set; }

        [Required]
        [Column("Nom")]
        public String Nom { get; set; }

        [Required]
        [Column("Prenom")]
        public String Prenom { get; set; }

        [Required]
        [Column("DateNaissance")]
        public DateTime DateNaissance { get; set; }

        public int ClasseId { get; set; }

        [ForeignKey("ClasseId")]
        public Classe Classe { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Absence> Absences { get; set; }
    }
}
