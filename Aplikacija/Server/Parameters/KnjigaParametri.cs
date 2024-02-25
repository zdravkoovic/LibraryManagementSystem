using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Parameters
{
    public class KnjigaParametri
    {
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public int AutorId { get; set; }
        public List<int> KnjizevniZanroviIds { get; set; }
        public int KnjizevniRodId { get; set; }
        public int KnjizevnaVrstaId { get; set; }
        public IFormFile Slika { get; set; }
    }
}