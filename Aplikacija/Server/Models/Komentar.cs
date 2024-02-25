using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Komentar
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(4000)")]        
        [Required]
        public string Tekst { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public Korisnik Korisnik { get; set; }

        [Required]
        public Knjiga Knjiga { get; set; }
    }
}