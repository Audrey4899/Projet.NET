using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Entites
{
    [Table("Absence")]
    public class Absence
    {
        [Key]
        [Column("AbsenceId")]
        public int AbsenceId { get; set; }

        [Required]
        [Column("Motif")]
        public String Motif { get; set; }

        [Required]
        [Column("BateAbsence")]
        public DateTime DateAbsence { get; set; }

        public int EleveId { get; set; }

        [ForeignKey("EleveId")]
        public Eleve Eleve { get; set; }
    }
}
