using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Citaonica
    {
        [Key]
        public int Id { get; protected set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naziv { get; set; }

        public int BrojVrsta { get; set; }

        public int BrojKolona { get; set; }

        [Required]
        public OgranakBiblioteke OgranakBiblioteke { get; set; }

        public List<Mesto> Mesta { get; set; }
    }
}