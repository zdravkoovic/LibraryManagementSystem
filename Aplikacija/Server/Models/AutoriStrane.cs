using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [NotMapped]
    public class AutoriStrane
    {
        public List<Autor> Autori { get; set; }

        public int BrojStrana { get; set; }
    }
}