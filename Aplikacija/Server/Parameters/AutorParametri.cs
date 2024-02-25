using System;
using Microsoft.AspNetCore.Http;

namespace Parameters
{
    public class AutorParametri
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string MestoRodjenja { get; set; }
        public string MestoSmrti { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public DateTime? DatumSmrti { get; set; }
        public string OAutoru { get; set; }
        public IFormFile Slika { get; set; }
    }
}