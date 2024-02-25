using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class FizickaKnjiga
    {
        [Key]
        public int Id { get; protected set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Sifra { get; set; }

        [Required]
        public Knjiga Knjiga { get; set; }

        public List<Iznajmljivanje> Iznajmljivanja { get; set; }

        public List<Citanje> Citanja { get; set; }

        public Jezik Jezik { get; set; }

        [Required]
        public OgranakBiblioteke OgranakBiblioteke { get; set; }

        public Izdavac Izdavac { get; set; }

        [Required]
        public bool Slobodna { get; set; }
    }
}