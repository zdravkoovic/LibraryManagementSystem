using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Citanje
    {
        [Key]
        public int Id { get; protected set; }

        [Required]
        public DateTime? VremeUzimanjaKnjige { get; set; }

        public DateTime? VremeVracanjaKnjige { get; set; }

        [Required]
        public FizickaKnjiga FizickaKnjiga { get; set; }

        [Required]
        public Korisnik Korisnik { get; set; }

        [Required]
        public Radnik RadnikDodelio { get; set; }

        public Mesto Mesto { get; set; }
    }
}