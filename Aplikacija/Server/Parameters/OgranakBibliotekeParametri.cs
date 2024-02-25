using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Parameters
{
    public class OgranakBibliotekeParametri
    {
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Kontakt { get; set; }
        public List<IFormFile> Slike { get; set; }
    }
}