using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Entites
{
    [Table("Note")]
    public class Note
    {
        [Key]
        [Column("NoteId")]
        public int NoteId { get; set; }

        [Required]
        [Column("Matiere")]
        public String Matiere { get; set; }

        [Required]
        [Column("DateNote")]
        public DateTime DateNote { get; set; }

        [Required]
        [Column("Appreciation")]
        public String Appreciation { get; set; }

        [Required]
        [Column("NoteValeur")]
        public int NoteValeur { get; set; }

        public int EleveId { get; set; }

        [ForeignKey("EleveId")]
        public Eleve Eleve { get; set; }
    }
}
