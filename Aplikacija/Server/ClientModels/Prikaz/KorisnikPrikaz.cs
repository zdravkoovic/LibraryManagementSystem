using System;

namespace ClientModels.Prikaz
{
    public class KorisnikPrikaz
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime? DatumPlacanjaClanarine { get; set; }
        public float Kazna { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }
        public string Email { get; set; }
    }
}