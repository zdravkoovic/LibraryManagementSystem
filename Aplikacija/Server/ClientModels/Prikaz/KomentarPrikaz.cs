using System;

namespace ClientModels.Prikaz
{
    public class KomentarPrikaz
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikId { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public int KnjigaId { get; set; }
    }
}