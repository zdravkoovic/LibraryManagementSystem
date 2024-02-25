using System;
using Microsoft.AspNetCore.Mvc;

namespace ClientModels.Prikaz
{
    public class AutorPrikaz
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Slika { get; set; }
        public string MestoRodjenja { get; set; }
        public string MestoSmrti { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public DateTime? DatumSmrti { get; set; }
        public string OAutoru { get; set; }
    }
}