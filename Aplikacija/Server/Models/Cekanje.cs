using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Cekanje
    {
        [Key]
        public int Id { get; protected set; }

        [Required]
        public DateTime? Datum { get; set; }

        [Required]
        public Knjiga Knjiga { get; set; }

        [Required]
        public Korisnik Korisnik { get; set; }
    }
}