using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Autor
    {
        [Key]
        public int Id { get; protected set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Ime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Prezime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MestoRodjenja { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MestoSmrti { get; set; }
        
        public DateTime? DatumRodjenja { get; set; }

        public DateTime? DatumSmrti { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string OAutoru { get; set; }

        public Slika Slika { get; set; }

        public List<Knjiga> Knjige { get; set; }
    }
}