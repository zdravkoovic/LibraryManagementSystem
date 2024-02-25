using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Vest
    {
        [Key]
        public int Id { get; protected set; }
        
        [Required]
        public Radnik Radnik { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naslov { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        [Required]
        public string Tekst { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public List<Slika> Slike { get; set; }
    }
}