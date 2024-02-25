using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Korisnik
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
        [Required]
        public string KorisnickoIme { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        [Required]
        public string Lozinka { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Kontakt { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<Komentar> Komentari { get; set; }

        public List<Iznajmljivanje> Iznajmljivanja { get; set; }

        public List<Cekanje> Cekanja { get; set; }

        public List<Citanje> Citanja { get; set; }

        public DateTime? DatumPlacanjaClanarine { get; set; }

        public DateTime? DatumProverePlacanjaClanarine { get; set; }

        public float Kazna { get; set; }
    }
}