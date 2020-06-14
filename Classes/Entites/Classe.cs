using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Entites
{
    [Table("Classe")]
    public class Classe
    {
        [Key]
        [Column("ClasseId")]
        public int ClasseId { get; set; }

        [Required]
        [Column("NomEtablissement")]
        public String NomEtablissement { get; set; }

        [Required]
        [Column("Niveau")]
        public String Niveau { get; set; }

        public ICollection<Eleve> Eleves { get; set; }
    }
}
