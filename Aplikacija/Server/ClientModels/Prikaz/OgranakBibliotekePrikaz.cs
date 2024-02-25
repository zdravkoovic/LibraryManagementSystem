using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ClientModels.Prikaz
{
    public class OgranakBibliotekePrikaz
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Kontakt { get; set; }
        public List<string> Slike { get; set; }
    }
}