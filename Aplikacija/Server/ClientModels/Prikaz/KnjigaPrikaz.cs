using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ClientModels.Prikaz
{
    public class KnjigaPrikaz
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Slika { get; set; }
        public int? AutorId { get; set; }
        public string AutorIme { get; set; }
        public string AutorPrezime { get; set; }
        public string Opis { get; set; }
        public List<string> KnjizevniZanrovi { get; set; }
        public string KnjizevniRod { get; set; }
        public string KnjizevnaVrsta { get; set; }
        public bool Slobodna { get; set; }
    }
}