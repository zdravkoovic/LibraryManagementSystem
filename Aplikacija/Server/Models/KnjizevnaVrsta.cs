using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class KnjizevnaVrsta
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naziv { get; set; }

        [Required]
        public KnjizevniRod KnjizevniRod { get; set; }
    }
}