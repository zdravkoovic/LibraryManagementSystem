using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Knjiga
    {
        [Key]
        public int Id { get; protected set; }
        
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Naslov { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Opis { get; set; }

        public Autor Autor { get; set; }

        public List<KnjizevniZanr> KnjizevniZanrovi { get; set; }

        public KnjizevniRod KnjizevniRod { get; set; }

        public KnjizevnaVrsta KnjizevnaVrsta { get; set; }
        
        public List<Komentar> Komentari { get; set; }

        public List<Cekanje> Cekanja { get; set; }

        public List<FizickaKnjiga> FizickeKnjige { get; set; }
        
        public Slika Slika { get; set; }
    }
}