using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Mesto
    {
        [Key]
        public int Id { get; protected set; }
        
        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }

        [Required]
        public Citaonica Citaonica { get; set; }

        [Required]
        public bool Racunar { get; set; }

        public List<Citanje> Citanja { get; set; }

        [Required]
        public bool Zauzeto { get; set; }
    }
}