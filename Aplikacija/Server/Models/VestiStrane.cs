using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [NotMapped]
    public class VestiStrane
    {
        public List<Vest> Vesti { get; set; }

        public int BrojStrana { get; set; }
    }
}