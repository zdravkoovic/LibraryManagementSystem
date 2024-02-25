using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Parameters
{
    public class VestParametri
    {
        public int RadnikId { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public List<IFormFile> Slike { get; set; }
    }
}