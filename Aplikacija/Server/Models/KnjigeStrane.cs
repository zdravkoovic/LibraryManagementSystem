using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [NotMapped]
    public class KnjigeStrane
    {
        public List<Knjiga> Knjige { get; set; }

        public int BrojStrana { get; set; }
    }
}