using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class OgranakBiblioteke
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naziv { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Adresa { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Kontakt { get; set; }

        public List<FizickaKnjiga> FizickeKnjige { get; set; }

        public List<Citaonica> Citaonice { get; set; }

        public List<Prijava> Prijave { get; set; }

        public List<Slika> Slike { get; set; }
    }
}