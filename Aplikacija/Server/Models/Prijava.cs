using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Prijava
    {
        [Key]
        public int Id { get; protected set; }
        
        [Required]
        public Radnik Radnik { get; set; }

        public OgranakBiblioteke OgranakBiblioteke { get; set; }

        [Required]
        public DateTime VremePrijave { get; set; }

        public DateTime? VremeOdjave { get; set; }
    }
}