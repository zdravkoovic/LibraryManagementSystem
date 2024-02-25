using System;

namespace ClientModels.Prikaz
{
    public class PrijavaPrikaz
    {
        public int Id { get; set; }
        public int RadnikId { get; set; }
        public string RadnikKorisnickoIme { get; set; }
        public bool Menadzer { get; set; }
        public int? OgranakBibliotekeId { get; set; }
        public string OgranakBibliotekeNaziv { get; set; }
        public DateTime? VremePrijave { get; set; }
        public DateTime? VremeOdjave { get; set; }
    }
}