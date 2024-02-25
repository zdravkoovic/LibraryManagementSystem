using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Iznajmljivanje
    {
        [Key]
        public int Id { get; protected set; }
        
        [Required]
        public Korisnik Korisnik { get; set; }

        [Required]
        public Radnik RadnikDodelio { get; set; }

        [Required]
        public OgranakBiblioteke OgranakBiblioteke { get; set; }

        [Required]
        public FizickaKnjiga FizickaKnjiga { get; set; }

        [Required]
        public DateTime? DatumIznajmljivanja { get; set; }

        public DateTime? DatumVracanja { get; set; }

        [Required]
        public DateTime DatumProvere { get; set; }

        public float Kazna { get; set; }
    }
}