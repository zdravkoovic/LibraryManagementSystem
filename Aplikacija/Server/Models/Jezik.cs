using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Jezik
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naziv { get; set; }
    }
}