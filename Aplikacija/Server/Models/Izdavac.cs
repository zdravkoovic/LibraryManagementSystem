using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Izdavac
    {
        [Key]
        public int Id { get; protected set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naziv { get; set; }

        public List<FizickaKnjiga> FizickeKnjige { get; set; }
    }
}