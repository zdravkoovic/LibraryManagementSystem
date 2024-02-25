using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Raspored
    {
        [Key]
        public int Id { get; protected set; }
        
        [Required]
        public Radnik Radnik { get; set; }

        public Radnik Menadzer { get; set; }

        public OgranakBiblioteke OgranakBiblioteke { get; set; }

        public DateTime? DatumOd { get; set; }

        public DateTime? DatumDo { get; set; }
    }
}