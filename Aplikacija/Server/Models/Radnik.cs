using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Radnik
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(13)]
        [Required]
        public string JMBG { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Ime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Prezime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string KorisnickoIme { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        [Required]
        public string Lozinka { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Kontakt { get; set; }

        [Required]
        public bool Menadzer { get; set; }

        public List<Prijava> Prijave { get; set; }
    }
}