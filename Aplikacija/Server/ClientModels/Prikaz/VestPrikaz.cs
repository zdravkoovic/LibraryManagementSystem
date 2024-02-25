using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ClientModels.Prikaz
{
    public class VestPrikaz
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public string RadnikKorisnickoIme { get; set; }
        public List<string> Slike { get; set; }
    }    
}