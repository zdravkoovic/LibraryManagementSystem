using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Slika
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(1000)")]
        [Required]
        [Url]
        public string Link { get; set; }

        
    }
}